using System;
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
    //UI
    public Text posiciones;
    //Referencias a prefabs modulos
    public GameObject prefabModuloRecta, prefabModuloCerrada, prefabModuloAbierta, prefabModuloZigZag, prefabModuloVuelta, prefabModuloChicane, prefabModuloEspecialCambio,prefabMontaña,prefabBurbujas,prefabMeteoritos,prefabElectrico;
    //Referencias a prefab Circuito
    public GameObject prefabCircuito;

    public Circuito creado;
    //Para la camara
    private int numModulos;
    private Vector3 centro = Vector3.zero;


    #region Metodos Construccion
    public void ConstruirCircuito(string nombre)
    {
        //DataCircuito datos = CargarCircuito("prueba");
        string datos = CargarCircuitoMongo("prueba");
        DataCircuito data = ParseMongo(datos);
        DataToCircuito(data);
    }

    private void DataToCircuito( DataCircuito datos)
    {
        Circuito nuevo = Instantiate(prefabCircuito, Vector3.zero, Quaternion.identity).GetComponent<Circuito>();
        nuevo.numVueltas = datos.numVueltas;
        Vector3 posSiguiente = nuevo.transform.position;
        numModulos = datos.modulos.Count;
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
                case TipoModulo.MONTANHA:
                    nuevoModulo = Instantiate(prefabMontaña, posSiguiente, Quaternion.identity).GetComponent<Modulo>();
                    break;
                case TipoModulo.ELECTRICO:
                    nuevoModulo = Instantiate(prefabElectrico, posSiguiente, Quaternion.identity).GetComponent<Modulo>();
                    break;
                case TipoModulo.BURBUJAS:
                    nuevoModulo = Instantiate(prefabBurbujas, posSiguiente, Quaternion.identity).GetComponent<Modulo>();
                    break;
                case TipoModulo.ASTEROIDES:
                    nuevoModulo = Instantiate(prefabMeteoritos, posSiguiente, Quaternion.identity).GetComponent<Modulo>();
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
            centro += nuevoModulo.transform.position;
            nuevoModulo.EliminarSockets();
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
        string data = ParseCircuito(datos);
        SaveCircuito("prueba", data);
        //SaveCircuito("prueba", datos);
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
        //for (int i = 0; i < resultado.modulos.Count; i++)
        //{
        //    if (i == resultado.modulos.Count - 1)
        //    {
        //        resultado.modulos[i].siguiente = null;
        //    }
        //    else
        //    {
        //        resultado.modulos[i].siguiente = resultado.modulos[i + 1];
        //    }
        //}
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
    private string CargarCircuitoMongo(string nombre)
    {
        string resultado="";
        string path = Application.persistentDataPath + "/savedCircuito" + nombre + ".gd";

        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            resultado = (string)bf.Deserialize(file);
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
    private void SaveCircuito(string nombre,string circuito)
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
        //btn.gameObject.SetActive(true);
        //btn.onClick.AddListener(() =>
        //{
          
        //    UIManagerCarrera ui = FindObjectOfType<UIManagerCarrera>();
        //    ui.circuito = creado;
        //    ui.posiciones = posiciones;
        //    CarreraController CC = FindObjectOfType<CarreraController>();
        //    CC.circuito = creado;
        //    ui.coches.AddRange(creado.pilotos);
        //    CC.EmpezarCarrera();
    
        //    // creado.IniciarCarrera();
        //});
        //CameraFuncionando(FindObjectOfType<CameraController>());
        
    }
    public void CameraFuncionando(CameraController camara)
    {

        camara.GirarEnCircuito(centro / numModulos, numModulos);
    }
    #endregion
    #region Parser
    private string ParseCircuito(DataCircuito datos)
    {
        int size = datos.modulos.Count;
        string res = size + "\n";
        res += datos.numVueltas + "\n";
        foreach(DataModulo data in datos.modulos)
        {
            res += (int)data.rotacion+":";
            res += (int)data.socketVecino + ":";
            res += (int)data.modulo + ":";
            res += data.sizeModulo + ":";
            if (data.reverse)
            {
                res += 1;
            }
            else
            {
                res += 0;
            }
            res += "\n";
        }
        return res;
    }
    private DataCircuito ParseMongo(string datos)
    {
        string[] datosSplit = datos.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries); 
        int size = int.Parse(datosSplit[0]);
        DataCircuito res = new DataCircuito(int.Parse(datosSplit[1]));
        for(int i=0; i < size; i++)
        {
            string[] datosModulo = datosSplit[i+2].Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
            DataModulo nuevo = new DataModulo();
            nuevo.rotacion = (Rotacion)int.Parse(datosModulo[0]);
            nuevo.socketVecino = (TipoSocket)int.Parse(datosModulo[1]);
            nuevo.modulo = (TipoModulo)int.Parse(datosModulo[2]);
            nuevo.sizeModulo = int.Parse(datosModulo[3]);
            if (int.Parse(datosModulo[4])==1)
            {
                nuevo.reverse = true;
            }
            else
            {
                nuevo.reverse = false;
            }
            res.modulos.Add(nuevo);
        }
        return res;
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
   // public DataModulo siguiente;
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