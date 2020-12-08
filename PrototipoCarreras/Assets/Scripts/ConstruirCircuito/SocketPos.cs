using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class SocketPos : MonoBehaviour
{

    private Modulo parent;
    private Modulo attach;
    private TipoSocket tipo;
     [SerializeField] private bool disponible = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void setParent(Modulo modulo)
    {
        parent = modulo;
        this.transform.parent = modulo.gameObject.transform;
    }
    public void setTipo(TipoSocket tipo)
    {
        this.tipo = tipo;
    }
    public void setDisponible(bool value)
    {
        disponible = value;
    }
    public void liberar()
    {
       
        attach = null;
        disponible = true;

        parent.RemoveVecino(tipo);
       

    }
    public void esSocketValido(Modulo m)
    {
        if (disponible)
        {
            switch (tipo)
            {
                case TipoSocket.NEGX:

                    if ((m.socket1.Equals(TipoSocket.POSX))||(m.socket2.Equals(TipoSocket.POSX))){
                        setAttach(m);
                        m.AddVecinoAndSocket(TipoSocket.POSX, parent);
                      
                        Vector3 posicion = new Vector3(transform.position.x- m.sizeModulo / 2, transform.position.y, transform.position.z);
                        m.transform.position =posicion;
                    }

                    break;
                case TipoSocket.NEGZ:
                    if ((m.socket1.Equals(TipoSocket.POSZ)) || (m.socket2.Equals(TipoSocket.POSZ))){
                        setAttach(m);
                        m.AddVecinoAndSocket(TipoSocket.POSZ, parent);
                        Vector3 posicion = new Vector3(transform.position.x, transform.position.y, transform.position.z - m.sizeModulo / 2);
                        m.transform.position = posicion;
                    }
                    break;
                case TipoSocket.POSX:
                    if ((m.socket1.Equals(TipoSocket.NEGX)) || (m.socket2.Equals(TipoSocket.NEGX))){
                        setAttach(m);
                        m.AddVecinoAndSocket(TipoSocket.NEGX, parent);
                        Vector3 posicion = new Vector3(transform.position.x + m.sizeModulo / 2, transform.position.y, transform.position.z);
                        m.transform.position = posicion;
                    }
                    break;
                case TipoSocket.POSZ:
                    if ((m.socket1.Equals(TipoSocket.NEGZ)) || (m.socket2.Equals(TipoSocket.NEGZ))){
                       setAttach(m);
                        m.AddVecinoAndSocket(TipoSocket.NEGZ, parent);
                        Vector3 posicion = new Vector3(transform.position.x, transform.position.y, transform.position.z +m.sizeModulo / 2);
                        m.transform.position = posicion;
                    }
                    break;
            }
        }
    }
    public void setAttach(Modulo modulo)
    {
        attach = modulo;
        disponible = false;
        parent.AddVecino(tipo,modulo);
        modulo.setAncla(this);
      
    }
  
   
 
    //private void OnCollisionExit(Collider other)
    //{

    //}
    // Update is called once per frame
    void Update()
    {
        
    }
}
