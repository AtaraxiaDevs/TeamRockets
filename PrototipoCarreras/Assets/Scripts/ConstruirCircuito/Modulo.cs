using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Esta clase gestiona los modulos. En el modo editor es muy util porque cuenta con eventos de colisiones y referencias a sus modulos vecinos.

[Serializable]
// Comparador de los módulos: así se sabrá en que orden estan
public class ComparadorModulo : Comparer<Modulo>
{
    public override int Compare(Modulo x, Modulo y)
    {
        return x.GetID()-y.GetID() ;
    }
}

// Información de los modulos unidos
[Serializable]
public class Vecino{
    public TipoSocket tipo;
    public Modulo attach;
}

[Serializable]
public class Modulo : MonoBehaviour
{
    //Los modulos tendran un prefab asociado, y unos sockets donde se uniran a los demás módulos

    //Referencias

    public ModuloInfo myInfo;
    private UIManagerEditor uiManager;
    public LineRenderer[] path;
    //Información de los sockets

    private SocketPos ancla1,ancla2;
    private GameObject refS1, refS2;
    public GameObject prefabSocket;
    public TipoSocket socket1, socket2;
    public Vector3 socketPosX, socketPosZ, socketNegX, socketNegZ;

    //Modulos vecinos, referencias
    [SerializeField]private Vecino vecino1, vecino2;


    //Información del modulo
    public Rotacion rotacion = Rotacion.NINGUNA;
    public bool modoConstructor = false;
    public bool cargadoFichero = true;
    public float sizeModulo;
    private int ID = -1;
    public bool esSalida, interactuable = true, reverse = false, selecPrimero = false;
    private bool soltado = false;

    #region Unity
    void Awake()
    {
        ForzarModulo();
        if (interactuable)
        {
            uiManager = FindObjectOfType<UIManagerEditor>();

            ancla1 = null; ancla2 = null;
            vecino1 = new Vecino();
            vecino2 = new Vecino();
            vecino1.tipo = socket1;
            vecino2.tipo = socket2;
            sizeModulo = GetComponent<MeshRenderer>().bounds.size.x;

            socketPosX = new Vector3(transform.position.x + sizeModulo / 2, transform.position.y, transform.position.z);
            socketNegX = new Vector3(transform.position.x - sizeModulo / 2, transform.position.y, transform.position.z);
            socketPosZ = new Vector3(transform.position.x, transform.position.y, transform.position.z + sizeModulo / 2);
            socketNegZ = new Vector3(transform.position.x, transform.position.y, transform.position.z - sizeModulo / 2);

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
    #endregion
    #region Modo Editor

    private void ForzarModulo()
    {
        if ((path[0] == null)||(!cargadoFichero))
        {
            return;
        }
        
        //float origen = (3 * sizeModulo) / 10;

        //float decrement = (2 * sizeModulo) / 10;
        float origen = (3f ) / 10f;

        float decrement = (2f ) / 10f;

        // primero mover su transform al centro
        // segundo, forzar  todos los puntos a su respectivo sitio
        //= en cuanto al principio y final, +, en cuanto a lo sdemas

        for (int i = 0; i < path.Length; i++) // en la carrera su padre es el circuito, tener cuidado!!!
        {
            ////path[i].transform.position = transform.TransformPoint(Vector3.zero) + new Vector3(0, path[i].transform.position.y, 0);
            //if (transform.parent != null)
            //{
            //  //  path[i].transform.localposition = transform.parent.TransformPoint(centro.transform.position);
            //}
            //else
            //{
            //    path[i].transform.position = centro.transform.position;


            //    // + new Vector3(0, path[i].transform.position.y, 0);
            //}
            int posPrimero = path[i].positionCount - 1;
            switch (socket1)
            {
                case TipoSocket.NEGX:
                    Vector3 aux = new Vector3(path[i].GetPosition(posPrimero).x, path[i].GetPosition(posPrimero).y, origen - decrement * i);

                    path[i].SetPosition(posPrimero, aux);
                    aux = new Vector3(0, 0, origen - decrement * i);
                    for (int j = 1; j < posPrimero; j++)
                    {
                        path[i].SetPosition(j, path[i].GetPosition(j) + aux);
                    }
                    break;
                case TipoSocket.NEGZ:
                    Vector3 aux2 = new Vector3(-origen + decrement * i, path[i].GetPosition(posPrimero).y, path[i].GetPosition(posPrimero).z);

                    path[i].SetPosition(posPrimero, aux2);
                    aux2 = new Vector3(-origen + decrement * i, 0, 0);
                    for (int j = 1; j < posPrimero; j++)
                    {
                        path[i].SetPosition(j, path[i].GetPosition(j) + aux2);
                    }
                    break;
                case TipoSocket.POSX:
                    Vector3 aux3 = new Vector3(path[i].GetPosition(posPrimero).x, path[i].GetPosition(posPrimero).y, -origen + decrement * i);

                    path[i].SetPosition(posPrimero, aux3);
                    aux3 = new Vector3(0, 0, -origen + decrement * i);
                    for (int j = 1; j < posPrimero; j++)
                    {
                        path[i].SetPosition(j, path[i].GetPosition(j) + aux3);
                    }
                    break;
                case TipoSocket.POSZ:
                    Vector3 aux4 = new Vector3(origen - decrement * i, path[i].GetPosition(posPrimero).y, path[i].GetPosition(posPrimero).z);

                    path[i].SetPosition(posPrimero, aux4);
                    aux4 = new Vector3(origen - decrement * i, 0, 0);
                    for (int j = 1; j < posPrimero; j++)
                    {
                        path[i].SetPosition(j, path[i].GetPosition(j) + aux4);
                    }
                    break;
                default:
                    break;
            }
            switch (socket2)
            {
                case TipoSocket.NEGX:
                  
                      
                        Vector3 aux = new Vector3(path[i].GetPosition(0).x, path[i].GetPosition(0).y, -origen + decrement * i);
                        path[i].SetPosition(0, aux);
                    

                    break;
                case TipoSocket.NEGZ:
                   
                        Vector3 aux1 = new Vector3(origen - decrement * i, path[i].GetPosition(0).y, path[i].GetPosition(0).z);
                        path[i].SetPosition(0, aux1);
                    

                    break;
                case TipoSocket.POSX:
                  
                        Vector3 aux2 = new Vector3(path[i].GetPosition(0).x, path[i].GetPosition(0).y, origen - decrement * i);
                        path[i].SetPosition(0, aux2);
                    

                    break;
                case TipoSocket.POSZ:
                   
                        Vector3 aux3 = new Vector3(-origen + decrement * i, path[i].GetPosition(0).y, path[i].GetPosition(0).z);
                        path[i].SetPosition(0, aux3);
                    

                    break;
                default:
                    break;
            }
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
        return vecino1.attach == null || vecino2.attach == null;
    }

    public void soyPrimero()
    {
        ID = 0;
        vecino2.attach.NumerarSiguiente(this, 1);
    }

    public void NumerarSiguiente(Modulo s, int id)
    {
        if (!modoConstructor)
        {
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
        else
        {
            ID = id;
            if (reverse)
            {
                if (vecino1.attach != null)
                {
                    vecino1.attach.NumerarSiguiente(this, id + 1);
                }
             
            }
            else
            {
                if (vecino2.attach != null)
                {
                    vecino2.attach.NumerarSiguiente(this, id + 1);
                }
            }
        }

        //viene del anterior
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

        if (ancla2 != null)
        {
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

        switch (rotacion)
        {
            case Rotacion.NINGUNA:
                rotacion = Rotacion.NOVENTAGRADOS;
                break;
            case Rotacion.NOVENTAGRADOS:
                rotacion = Rotacion.CIENTOCHENTAGRADOS;
                break;
            case Rotacion.CIENTOCHENTAGRADOS:
                rotacion = Rotacion.DOSCIENTOSSETENTAGRADOS;
                break;
            case Rotacion.DOSCIENTOSSETENTAGRADOS:
                rotacion = Rotacion.NINGUNA;
                break;
        }
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

    #endregion
    #region Modo Carrera
    public void EliminarSockets()
    {
        Destroy(refS2);
        Destroy(refS1);
    }
    #endregion
    #region Coger informacion
    public int GetID()
    {
        return ID;
    }
    #endregion
    #region Eventos Input

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

            if (inputMouse.x > 0 && inputMouse.y > 0 && inputMouse.x < Camera.main.pixelWidth && inputMouse.y < Camera.main.pixelHeight)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(inputMouse);
                transform.position = new Vector3(pos.x, transform.position.y, pos.z);
            }
        }
    }

    #endregion
    #region Eventos Collider
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
        if (other.tag.Equals("Coche"))
        {
            if (other.GetComponent<Coche>().iniciado)
            {
                if (!other.GetComponent<Coche>().currentModulo.Equals(myInfo))
                {
                    other.GetComponent<Coche>().currentModulo = myInfo;
                    other.GetComponent<Coche>().currentPointMod = 0;
                    if (!myInfo.tipoCircuito.Equals(TipoModulo.CAMBIOCARRIL))
                    {
                        other.GetComponent<Coche>().sizeMod = path[0].positionCount;
                    }
                    else
                    {
                        if (other.GetComponent<Coche>().ultimaVueltaCambio != other.GetComponent<Coche>().vuelta)
                        {
                            other.GetComponent<Coche>().CambiarCarril();
                            other.GetComponent<Coche>().ultimaVueltaCambio = other.GetComponent<Coche>().vuelta;


                        }
                       
                    }

                  
                }
                other.GetComponent<IAMoves>().ModuloSiguiente(ID);
                //Si el tipo es el especial, le dice al coche que haga una voltereta o algo
            }
        }
    }

    #endregion


}
