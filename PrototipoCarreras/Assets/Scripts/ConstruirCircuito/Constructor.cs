using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

//Recibirá la información de un circuito gracias a Mongo y con ello creará un circuito desde 0
//primero con almacenamiento interno, mas adelante en mongo
public class Constructor : MonoBehaviour
{
    //Referencias a prefabs modulos
    public GameObject prefabModuloRecta, prefabModuloCerrada, prefabModuloAbierta, prefabModuloZigZag, prefabModuloVuelta, prefabModuloChicane, prefabModuloEspecialCambio;
    //Referencias a prefab Circuito
    public GameObject prefabCircuito;

    private Circuito creado;

    #region Metodos Construccion
    public void ConstruirCircuito(string nombre)
    {
        DataCircuito datos = CargarCircuito("prueba");
        DataToCircuito(datos);
    }

    private void DataToCircuito( DataCircuito datos)
    {
        Circuito nuevo = Instantiate(prefabCircuito, Vector3.zero, Quaternion.identity).GetComponent<Circuito>();
        nuevo.numVueltas = datos.numVueltas;
        Vector3 posSiguiente = nuevo.transform.position;

        foreach (DataModulo dm in datos.modulos)
        {
            TipoModulo tm = dm.modulo;
            Modulo nuevoModulo;

            switch(tm)
            {
                case TipoModulo.CHICANE:
                    nuevoModulo = Instantiate(prefabModuloChicane, posSiguiente, Quaternion.identity).GetComponent<Modulo>();
                    break;
                case TipoModulo.CURVABIERTA:
                    nuevoModulo = Instantiate(prefabModuloAbierta, posSiguiente, Quaternion.identity).GetComponent<Modulo>();
                    break;
                case TipoModulo.RECTA:
                    nuevoModulo = Instantiate(prefabModuloRecta, posSiguiente, Quaternion.identity).GetComponent<Modulo>();
                    break;
                case TipoModulo.VUELTA:
                    nuevoModulo = Instantiate(prefabModuloVuelta, posSiguiente, Quaternion.identity).GetComponent<Modulo>();
                    break;
                case TipoModulo.ZIGZAG:
                    nuevoModulo = Instantiate(prefabModuloZigZag, posSiguiente, Quaternion.identity).GetComponent<Modulo>();
                    break;
                case TipoModulo.CURVACERRADA:
                    nuevoModulo = Instantiate(prefabModuloCerrada, posSiguiente, Quaternion.identity).GetComponent<Modulo>();
                    break;
                case TipoModulo.CAMBIOCARRIL:
                    nuevoModulo = Instantiate(prefabModuloEspecialCambio, posSiguiente, Quaternion.identity).GetComponent<Modulo>();
                    break;
                default:
                    nuevoModulo = Instantiate(prefabModuloRecta, posSiguiente, Quaternion.identity).GetComponent<Modulo>();
                    break;

            }

            Rotacion r = dm.rotacion;
            switch (r)
            {
                case Rotacion.NINGUNA:
                    break;
                case Rotacion.NOVENTAGRADOS:
                    nuevoModulo.Rotar();
                    break;
                case Rotacion.CIENTOCHENTAGRADOS:
                    for(int i=0; i < 2; i++)
                    {
                        nuevoModulo.Rotar();
                    }
                    
                    break;
                case Rotacion.DOSCIENTOSSETENTAGRADOS:
                    for (int i = 0; i < 3; i++)
                    {
                        nuevoModulo.Rotar();
                    }

                    break;
            }
            
            TipoSocket ts = dm.socketVecino;
            Vector3 offset = nuevoModulo.transform.position;

            switch (ts)
            {
                case TipoSocket.POSX:
                    offset += new Vector3(dm.sizeModulo, 0, 0);
                    break;
                case TipoSocket.POSZ:
                    offset += new Vector3(0, 0, dm.sizeModulo);
                    break;
                case TipoSocket.NEGZ:
                    offset += new Vector3(0, 0, -dm.sizeModulo);
                    break;
                case TipoSocket.NEGX:
                    offset +=new Vector3(-dm.sizeModulo, 0, 0);
                    break;
            }

            posSiguiente = offset;
            nuevoModulo.reverse = dm.reverse;
            nuevoModulo.modoConstructor = true;
            nuevoModulo.interactuable = false;
            nuevo.AddModulo(nuevoModulo);
        }

        for (int i = 0; i < nuevo.modulos.Count-1; i++)
        {
            //Poner el siguiente
            if(nuevo.modulos[i].reverse)
            {
                nuevo.modulos[i].AddVecino(nuevo.modulos[i].socket1, nuevo.modulos[i + 1]);
            }
            else
            {
                nuevo.modulos[i].AddVecino(nuevo.modulos[i].socket2, nuevo.modulos[i + 1]);
            }

        }

        nuevo.modulos[0].soyPrimero();
        nuevo.moduloPrimero = nuevo.modulos[0];
        nuevo.CrearPilotos();
        creado = nuevo;
    }
    #endregion
    #region Metodos Guardado
    public void GuardarCircuito(Circuito circuito)
    {
        DataCircuito datos = CircuitoToData(circuito);
        SaveCircuito("prueba", datos);
    }
    private DataCircuito CircuitoToData(Circuito circuito)
    {
        DataCircuito resultado = new DataCircuito(circuito.numVueltas);

        foreach (Modulo m in circuito.modulos)
        {
            DataModulo data = new DataModulo();
            data.rotacion = m.rotacion;
            data.modulo = m.myInfo.tipoCircuito;
            data.reverse = m.reverse;
            data.sizeModulo = m.sizeModulo;

            if (m.reverse)
            {
                data.socketVecino = m.socket1;
            }
            else
            {
                data.socketVecino = m.socket2;
            }

            resultado.modulos.Add(data);
        }
        for (int i = 0; i < resultado.modulos.Count; i++)
        {
            if (i == resultado.modulos.Count - 1)
            {
                resultado.modulos[i].siguiente = null;
            }
            else
            {
                resultado.modulos[i].siguiente = resultado.modulos[i + 1];
            }
        }
        return resultado;
    }
    #endregion
    #region Metodos IO

    private DataCircuito CargarCircuito(string nombre)
    {
        DataCircuito resultado;
        string path = Application.persistentDataPath + "/savedCircuito" + nombre + ".gd";

        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            resultado = (DataCircuito)bf.Deserialize(file);
            file.Close();
            return resultado;
        }
        else
        {
            return null;
        }
    }

    private void SaveCircuito(string nombre, DataCircuito circuito)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savedCircuito" + nombre + ".gd";
        FileStream file = File.Create(path);
        bf.Serialize(file, circuito);
        file.Close();

    }
    #endregion
    #region UI
    public void EmpezarCarreraListener( Button btn)
    {
        btn.gameObject.SetActive(true);
        btn.onClick.AddListener(() =>
        {
            creado.Construir(); 
            creado.IniciarCarrera();
        });
    }
    #endregion


}

[System.Serializable]
public class DataCircuito
{
    public List<DataModulo> modulos;
    public int numVueltas;

    public DataCircuito(int vueltas)
    {
        modulos = new List<DataModulo>();
        numVueltas = vueltas;
    }
}

[System.Serializable]
public class DataModulo
{
    public DataModulo siguiente;
    public Rotacion rotacion;
    public TipoSocket socketVecino;
    public TipoModulo modulo;
    public float sizeModulo;
    public bool reverse;
}

public enum Rotacion
{
    NINGUNA,
    NOVENTAGRADOS,
    CIENTOCHENTAGRADOS,
    DOSCIENTOSSETENTAGRADOS,
}