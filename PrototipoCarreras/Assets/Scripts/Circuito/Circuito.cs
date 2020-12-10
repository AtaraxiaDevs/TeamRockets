using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectCircuito
{
    public GameObject circuito;
}
[Serializable]
public class Circuito : MonoBehaviour
{
    //El circuito estará formado por una serie de módulos y de lineas que conformarán una unica linea
    // Start is called before the first frame update
    private List<Modulo> modulos;
    //private List<GameObject> gameObjectModulo;
    private LineRenderer[] circuito;
    private static int maxPilotos = 4;
    private int[] vertexcont = new int[maxPilotos];
    public Coche[] pilotos;
    public Transform prefabCircuito;
    public GameObject gameObjectCircuito;
    public bool modoEditor;
    void Start()
    {
        if (modoEditor)
        {
            modulos = new List<Modulo>();
            circuito = new LineRenderer[maxPilotos];
            pilotos = new Coche[maxPilotos];
            for (int i = 0; i < maxPilotos; i++)
            {
                Transform mytmp = Instantiate(prefabCircuito, transform);
                pilotos[i] = mytmp.GetComponentInChildren<Coche>();
                pilotos[i].ID = i;
                circuito[i] = mytmp.GetComponent<LineRenderer>();
            }
            for (int i = 0; i < maxPilotos; i++)
            {
                vertexcont[i] = 0;
            }
        }


        //construir();
    }
    public void IniciarCarrera()
    {
        for (int i = 0; i < maxPilotos; i++)
        {
            pilotos[i].Init();
        }
    }
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

    //public bool buenaDireccion(Vector3 posModulo, LineRenderer lineProxModulo,Transform t)
    //{
    //    float distance1 = Mathf.Abs(Vector3.Distance( posModulo , t.TransformPoint(lineProxModulo.GetPosition(0))));
    //    float distance2 = Mathf.Abs(Vector3.Distance(posModulo, t.TransformPoint(lineProxModulo.GetPosition(lineProxModulo.positionCount-1))));
    //    Debug.Log("Distancia1 " + distance1);
    //    Debug.Log("Distancia2 " + distance2);
    //    return distance2 > distance1;

    //}

    public void construir()
    {

        modulos.Sort(new ComparadorModulo());
        for (int h = 0; h < modulos.Count; h++)
        {
            modulos[h].transform.parent = this.transform;

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

    void Update()
    {

    }
}
