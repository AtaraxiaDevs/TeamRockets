using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class ComparadorModulo : Comparer<Modulo>
{
    public override int Compare(Modulo x, Modulo y)
    {
        return x.GetID()-y.GetID() ;
    }
}

[Serializable]
public class Vecino{
    public TipoSocket tipo;
    public Modulo attach;
}

[Serializable]
public class Modulo : MonoBehaviour
{
    //Los modulos tendran un prefab asociado, y unos sockets donde se uniran a los demás módulos

    //References

    public ModuloInfo myInfo;
    private UIManagerEditor uiManager;
 
    //Sockets

    private SocketPos ancla1,ancla2;
    private GameObject refS1, refS2;
    public GameObject prefabSocket;
    public TipoSocket socket1, socket2;
    public Vector3 socketPosX, socketPosZ, socketNegX, socketNegZ;

    [SerializeField] private Vecino vecino1, vecino2;

    public LineRenderer[] path;
    public float sizeModulo;
    private int ID = -1;

    public bool esSalida, interactuable = true, reverse = false, selecPrimero = false;
    private bool soltado = false;

    void Awake()
    {
        if (interactuable)
        {
            uiManager = FindObjectOfType<UIManagerEditor>();

            ancla1 = null; ancla2 = null;
            vecino1 = new Vecino();
            vecino2 = new Vecino();
            vecino1.tipo = socket1;
            vecino2.tipo = socket2;
            sizeModulo = GetComponent<MeshRenderer>().bounds.size.x;

            socketPosX = new Vector3(transform.position.x+sizeModulo/2,transform.position.y,transform.position.z);
            socketNegX = new Vector3(transform.position.x - sizeModulo / 2, transform.position.y, transform.position.z);
            socketPosZ = new Vector3(transform.position.x , transform.position.y, transform.position.z + sizeModulo / 2);
            socketNegZ = new Vector3(transform.position.x , transform.position.y, transform.position.z - sizeModulo / 2);
     
      
            switch (socket1)
            {
                case TipoSocket.NEGX:
                    refS1 = Instantiate(prefabSocket, socketNegX, transform.rotation);
                    break;

                case TipoSocket.NEGZ:
                    refS1 = Instantiate(prefabSocket, socketNegZ, transform.rotation);
                    break;

                case TipoSocket.POSX:
                    refS1 = Instantiate(prefabSocket, socketPosX, transform.rotation);
                    break;

                case TipoSocket.POSZ:
                    refS1 = Instantiate(prefabSocket, socketPosZ, transform.rotation);
                    break;

            }

            switch (socket2)
            {
                case TipoSocket.NEGX:
                    refS2 = Instantiate(prefabSocket, socketNegX, transform.rotation);
                    break;

                case TipoSocket.NEGZ:
                    refS2 = Instantiate(prefabSocket, socketNegZ, transform.rotation);
                    break;

                case TipoSocket.POSX:
                    refS2 = Instantiate(prefabSocket, socketPosX, transform.rotation);
                    break;

                case TipoSocket.POSZ:
                    refS2 = Instantiate(prefabSocket, socketPosZ, transform.rotation);
                    break;

            }

            refS1.GetComponent<SocketPos>().setParent(this);
            refS2.GetComponent<SocketPos>().setParent(this);
            refS1.GetComponent<SocketPos>().setTipo(socket1);
            refS2.GetComponent<SocketPos>().setTipo(socket2);
        }
    }

    public int GetID()
    {
        return ID;
    }

    public void SetAncla(SocketPos sp)
    {
        if (ancla1 == null)
        {
            ancla1 = sp;
        }
        else
        {
            ancla2 = sp;
        }
    }

    public void Liberar()
    {
        Debug.Log("Liberar");
        if (ancla1 != null)
        {
            ancla1.LiberarSocket();
            ancla1 = null;
        }

        if (ancla2 != null){
            ancla2.LiberarSocket();
            ancla2 = null;
        }

        vecino1.attach = null;
        vecino2.attach = null;
        refS1.GetComponent<SocketPos>().LiberarSocket();
        refS2.GetComponent<SocketPos>().LiberarSocket();
    }

    public void Rotar()
    {
        Liberar();
        transform.Rotate(0, 90, 0);

        switch (socket1)
        {
            case TipoSocket.NEGX:
                socket1 = TipoSocket.POSZ;
                break;

            case TipoSocket.NEGZ:
                socket1 = TipoSocket.NEGX;
                break;

            case TipoSocket.POSX:
                socket1 = TipoSocket.NEGZ;
                break;

            case TipoSocket.POSZ:
                socket1 = TipoSocket.POSX;
                break;
        }
  
        switch (socket2)
        {
            case TipoSocket.NEGX:
                socket2 = TipoSocket.POSZ;
                break;

            case TipoSocket.NEGZ:
                socket2 = TipoSocket.NEGX;
                break;

            case TipoSocket.POSX:
                socket2 = TipoSocket.NEGZ;
                break;

            case TipoSocket.POSZ:
                socket2 = TipoSocket.POSX;
                break;
        }
        refS1.GetComponent<SocketPos>().setTipo(socket1);
        refS2.GetComponent<SocketPos>().setTipo(socket2);
    }
    
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (interactuable)
            {
                soltado = true;
            }
        }
    }
    private void OnMouseDown()
    {
        if (interactuable)
        {
            Liberar();
            uiManager.current = this;
        }

        if (selecPrimero)
        {
            uiManager.current = this;
        }
        //modo seleccionar primero boolean
    }
  
    private void OnMouseDrag()
    {
        if (interactuable)
        {
            if (QuedaHueco())
            {
                Liberar();
            }

            soltado = false;
            Vector3 inputMouse = Input.mousePosition;
            Debug.Log(Camera.main.pixelWidth);

            if (inputMouse.x > 0 && inputMouse.y > 0 && inputMouse.x<Camera.main.pixelWidth && inputMouse.y< Camera.main.pixelHeight)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(inputMouse);
                transform.position = new Vector3(pos.x, transform.position.y, pos.z);
            }
        } 
    }
  
    private void OnTriggerStay(Collider other)
    {
        //solo en la construccion
        if (interactuable)
        {
            if ((uiManager.current != null))
            {
                if ((soltado) && (uiManager.current.Equals(this)))
                {
                    if (other.tag.Equals("SocketEditor"))
                    {
                        SocketPos otro = other.GetComponent<SocketPos>();

                        if (!(otro.Equals(ancla1) || otro.Equals(ancla2)))
                        {
                            other.GetComponent<SocketPos>().esSocketValido(this);
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Coche"))
        {
            other.GetComponent<Coche>().currentModulo = myInfo;
        }
    }

    public void AddVecinoAndSocket(TipoSocket tipo, Modulo m)
    {
        if (tipo.Equals(socket1))
        {
            refS1.GetComponent<SocketPos>().setAttach(m);
        }
        else if (tipo.Equals(socket2))
        {
            refS2.GetComponent<SocketPos>().setAttach(m);
        }
        else
        {
            Debug.Log("No posible añadir");
        }
    }

    public void AddVecino(TipoSocket tipo, Modulo m)
    {
        if (tipo.Equals(socket1))
        {
            vecino1.attach = m;
          
            Debug.Log("Añadido");
        }
        else if (tipo.Equals(socket2))
        {
            vecino2.attach = m;
            Debug.Log("Añadido");
        }
        else
        {
            Debug.Log("No posible añadir");
        }
    }

    public void RemoveVecino(TipoSocket tipo)
    {
        if (tipo.Equals(socket1))
        {
            vecino1.attach = null;
        }
        else if (tipo.Equals(socket2))
        {
            vecino2.attach = null;
        }
    }

    public bool QuedaHueco()
    {
        return vecino1.attach == null || vecino2.attach== null;
    }

    public void soyPrimero()
    {
        ID = 0;
        vecino2.attach.NumerarSiguiente(this,1);
    }

    public void NumerarSiguiente(Modulo s, int id)
    {
        //viene del anterior
        if (ID < 0)
        {
            ID = id;
            if (s.Equals(vecino1.attach))
            {

                vecino2.attach.NumerarSiguiente(this, id + 1);
            }
            else
            {
                reverse = true;// es decir, está al revés de como debería
                vecino1.attach.NumerarSiguiente(this, id + 1);
            }
        }
    }
}
