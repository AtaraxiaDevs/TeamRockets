using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class QRMANAGER : MonoBehaviour
{
    string _FileLocation, _FileName;
    ObjectCircuito objetoEscribir, objetoLeer;
    string _data;

    public void Guardar(Circuito c)
    {
        //c.Guardar();
        objetoEscribir = new ObjectCircuito();
        objetoEscribir.circuito = c.gameObject;
        _data = SerializeObject(objetoEscribir);
        CreateXML();
    }

    void CreateXML()
    {
        StreamWriter writer;
        FileInfo t = new FileInfo(_FileLocation + "\\" + _FileName);
        if (!t.Exists)
        {
            writer = t.CreateText();
        }
        else
        {
            t.Delete();
            writer = t.CreateText();
        }
        writer.Write(_data);
        writer.Close();
        Debug.Log("File written.");
    }
    string UTF8ByteArrayToString(byte[] characters)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        string constructedString = encoding.GetString(characters);
        return (constructedString);
    }
    string SerializeObject(ObjectCircuito ob)
    {
        string res = null;
        MemoryStream ms = new MemoryStream();
        XmlSerializer xs = new XmlSerializer(typeof(GameObject));
        XmlTextWriter xw = new XmlTextWriter(ms, Encoding.UTF8);
        xs.Serialize(xw, ob);
        ms = (MemoryStream)xw.BaseStream;
       res = UTF8ByteArrayToString(ms.ToArray());
        return res;
    }
    void Start()
    {
        _FileLocation = Application.dataPath;
        _FileName = "Prueba.xml";
    }
}
