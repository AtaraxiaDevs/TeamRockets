using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum TipoSocket{
    POSX,
    NEGX,
    POSZ,
    NEGZ
}
public class ComparadorModulo : Comparer<Modulo>
{
    public override int Compare(Modulo x, Modulo y)
    {
        return x.ID - y.ID;
    }
}
public class Modulo : MonoBehaviour
{
    //Los modulos tendran un prefab asociado, y unos sockets donde se uniran a los demás módulos
    // Start is called before the first frame update
    public Transform socketInicio;
    public Transform socketFinal;
    public GameObject modulo;
    public GameObject siguiente;
    public Modulo vecino1,vecino2;
    public TipoSocket socket1, socket2;
    public LineRenderer path;
    public bool esSalida;
    private Vector3 socketPosX, socketPosZ, socketNegX, socketNegZ;
    
    private float sizeModulo;
    public int ID=-1;



    private bool arrastrando = false;
    void Awake()
    {
        sizeModulo = GetComponent<MeshRenderer>().bounds.size.x;
        socketPosX=new Vector3(transform.position.x+sizeModulo/2,transform.position.y,transform.position.z);
        socketNegX = new Vector3(transform.position.x - sizeModulo / 2, transform.position.y, transform.position.z);
        socketPosZ = new Vector3(transform.position.x , transform.position.y, transform.position.z + sizeModulo / 2);
        socketNegZ = new Vector3(transform.position.x , transform.position.y, transform.position.z - sizeModulo / 2);
        if (siguiente != null)
        {
            siguiente.gameObject.transform.position = new Vector3(socketNegZ.x, socketNegZ.y, socketNegZ.z - sizeModulo / 2);
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void OnDrag(PointerEventData eventData)
    //{
    //    Plane plane = new Plane(Vector3.up, -0.5f);
    //    Ray ray = Camera.main.ScreenPointToRay(eventData.position);
    //    float enter;
    //    if (plane.Raycast(ray, out enter))
    //    {
    //        Vector3 rayPoint = ray.GetPoint(enter);
    //        transform.position = rayPoint;
    //    }
    //}
 
    private void OnMouseDrag()
    {
        if (arrastrando)
        {
            Vector3 pos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(pos.x, transform.position.y, pos.z);
        }
    }

    public bool QuedaHueco()
    {
        return socket1 == null || socket2 == null;
    }
    public void soyPrimero()
    {
        ID = 0;
        vecino1.NumerarSiguiente(this,1);
    }
    public void NumerarSiguiente(Modulo s, int id)
    {
        //viene del anterior
        if (ID < 0)
        {
            ID = id;
            if (modulo.Equals(vecino1))
            {

                vecino2.NumerarSiguiente(this, id + 1);
            }
            else
            {
                vecino1.NumerarSiguiente(this, id + 1);
            }
        }
       


    }
}
