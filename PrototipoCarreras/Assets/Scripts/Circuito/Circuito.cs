﻿using Photon.Pun;
using System;
using System.Collections.Generic;
using UnityEngine;


// Esta clase crea los linerenderer de los pilotos a partir de los linerenderer de los modulos que lo conforman. Cuenta con metodos
// que añaden y eliminan modulos, para gestionar los pilotos de la carrera, para construir el circuito etc.
//Un metodo importante es "Construir()" que es donde coge los linerenderer que seguiran los pilotos, y los modifica para que sigan el circuito
public class Circuito : MonoBehaviourPunCallbacks
{
    //El circuito estará formado por una serie de módulos y de lineas que conformarán una unica linea

    //Referencias
    public List<Modulo> modulos;
    public Modulo moduloPrimero;
    public Coche[] pilotos;
    public Transform prefabCircuito;
    public GameObject gameObjectCircuito;

    //Referencia a los circuitos de los pilotos
    private LineRenderer[] circuito;
 
    //información
    private static int maxPilotos = 4;
    private int[] vertexcont = new int[maxPilotos];
    public bool modoEditor;
    public int numVueltas= 3;

    #region Unity
    void Start()
    {
        circuito = new LineRenderer[maxPilotos];
        if (modoEditor)// Si estamos en el editor instanciamos los coches básicos
        {
            modulos = new List<Modulo>();
            CrearPilotos();
        }
        else
        {
            if (pilotos[0] != null)
            {
                InicializarPilotos();
            }

        }
        
    }
  
    #endregion
    #region Construir Circuito
    public void CrearPilotos()
    {
        circuito = new LineRenderer[maxPilotos];
        pilotos = new Coche[maxPilotos];

        for (int i = 0; i < maxPilotos; i++)
        {
            Transform mytmp = Instantiate(prefabCircuito, transform);
            pilotos[i] = mytmp.GetComponentInChildren<Coche>();
            pilotos[i].ID = i;
            pilotos[i].GetComponent<IAMoves>().currentCircuito = this;
            circuito[i] = mytmp.GetComponent<LineRenderer>();
        }

        for (int i = 0; i < maxPilotos; i++)
        {
            vertexcont[i] = 0;
        }
        AsignarPiloto();

    }
    public void InicializarPilotos()
    { //moduloPrimero.soyPrimero();
        for (int i = 0; i < maxPilotos; i++)
        {


            pilotos[i].ID = i;
            pilotos[i].GetComponent<IAMoves>().currentCircuito = this;
            circuito[i] = pilotos[i].GetComponentInParent<LineRenderer>();

        }
        AsignarPiloto();

    }
    public void Construir()
    {


        for (int h = 0; h < modulos.Count; h++)
        {


            for (int j = 0; j < maxPilotos; j++)
            {
                int posicionPath;

                if (modulos[h].reverse)
                {
                    posicionPath = maxPilotos - 1 - j;
                }
                else
                {
                    posicionPath = j;
                }

                LineRenderer path = modulos[h].path[posicionPath];
                Transform t = path.transform;

                if (modulos[h].reverse)
                {
                    Vector3[] pos = new Vector3[path.positionCount];
                    path.GetPositions(pos);
                    Debug.Log("Buena direccion");

                    for (int i = 0; i < path.positionCount - 1; i++)
                    {
                        Vector3 point = t.TransformPoint(pos[i]);
                        circuito[j].SetVertexCount(++vertexcont[j]);
                        circuito[j].SetPosition(vertexcont[j] - 1, point);
                    }
                }
                else
                {
                    Vector3[] pos = new Vector3[modulos[h].path[posicionPath].positionCount];
                    modulos[h].path[posicionPath].GetPositions(pos);
                    Debug.Log("Mala direccion");

                    for (int i = modulos[h].path[posicionPath].positionCount - 1; i >= 0; i--)
                    {
                        Vector3 point = t.TransformPoint(pos[i]);
                        circuito[j].SetVertexCount(++vertexcont[j]);
                        circuito[j].SetPosition(vertexcont[j] - 1, point);
                    }
                }
            }
        }

        for (int i = 0; i < maxPilotos; i++)
        {
            circuito[i].SetVertexCount(circuito[i].positionCount + 1);
            circuito[i].SetPosition(circuito[i].positionCount - 1, circuito[i].GetPosition(0));
        }
    }
    #endregion
    #region Modo Editor
    public void SetInteractuable(bool value)
    {
        foreach (Modulo m in modulos)
        {
            m.interactuable = value;
        }
    }

    public void AddModulo(Modulo m)
    {
        modulos.Add(m);
    }
    public void RemoveModulo(Modulo m)
    {
        modulos.Remove(m);
    }
    public bool CircuitoListo()
    {
        foreach (Modulo m in modulos)
        {
            if (m.QuedaHueco())
            {
                return false;
            }
        }
        return true;
    }

    public void TransformModulos()
    {
        modulos.Sort(new ComparadorModulo());
        for (int h = 0; h < modulos.Count; h++)
        {
            modulos[h].transform.parent = this.transform;
        }
    }
    #endregion
    #region Información Pilotos
    //Elegir cual es el coche jugador
    public void setMyPlayer(int i)
    {
        pilotos[i].soyPlayer = true;
        pilotos[i].gameObject.GetComponent<PhotonView>().SetOwnerInternal(PhotonNetwork.LocalPlayer, i);
    }
    //Variable multiplayer de todos los pilotos de la carrera a true ( en multijugador). Puede que no nos haga falta más adelante
    public void setMulti()
    {
        foreach (Coche p in pilotos)
        {
            p.multiPlayer = true;
        }
    }
    #endregion
    #region Modo Carrera
    private void AsignarPiloto()
    {
        InformacionPersistente ip = InformacionPersistente.singleton;
        for (int i = 0; i < ip.numCoches; i++)
        {
            if (ip.cochesCarrera[i] == null)
            {
                ip.GetRandomCoche(i);
            }
            pilotos[i].AsignarCoche(ip.cochesCarrera[i]);
        }
    }
    public void IniciarCarrera()
    {
        for (int i = 0; i < maxPilotos; i++)
        {
            pilotos[i].Init(moduloPrimero.myInfo);
        }
    }
    public Modulo GetModulo(int id)
    {
        if (id == modulos.Count)
        {
            return (modulos[0]);
        }
        else
        {
            return modulos[id];
        }
    }

    #endregion





 



}
