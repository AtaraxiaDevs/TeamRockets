using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerEditor : MonoBehaviour
{
    //References
    public Modulo current;
    public GameObject prefabRecta, prefabVuelta,prefabAbierta,prefabCerrada,prefabZigZag,prefabChicanne;
    public Circuito circuito;
    public QRMANAGER qrmanager;

    //UI
    public Button rotar, listoPrimero, Recta, Vuelta, Abierta, Cerrada, ZigZag, Chicanne, remove,listoConstruir, save;
    
    // Start is called before the first frame update
    void Start()
    {
        current = null;
        rotar.onClick.AddListener(() =>
        {
            if (current != null)
            {
                current.Rotar();
            }
        });

        remove.onClick.AddListener(() =>
        {
            if (current != null)
            {
                circuito.RemoveModulo(current);
                Destroy(current.gameObject);
               
            }
        });

        listoPrimero.onClick.AddListener(() => ComenzarCarrera());
        listoConstruir.onClick.AddListener(() => PantallaElegirPrimero());
        Recta.onClick.AddListener(() => CrearModulo(prefabRecta));
        ZigZag.onClick.AddListener(() => CrearModulo(prefabZigZag));
        Abierta.onClick.AddListener(() => CrearModulo(prefabAbierta));
        Vuelta.onClick.AddListener(() => CrearModulo(prefabVuelta));
        Cerrada.onClick.AddListener(() => CrearModulo(prefabCerrada));
        Chicanne.onClick.AddListener(() => CrearModulo(prefabChicanne));
        //save.onClick.AddListener(() => qrmanager.Guardar(circuito));
        save.onClick.AddListener(() => circuito.IniciarCarrera()) ;
    }

    private void CrearModulo(GameObject prefab)
    {
       //Debemos poner un punto de spawn
        Vector3 posicion = new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z);

        GameObject nuevoModulo = Instantiate(prefab,posicion,Quaternion.identity);
       // nuevoModulo.transform.Rotate
        circuito.AddModulo(nuevoModulo.GetComponent<Modulo>()); 
    }
    private void ComenzarCarrera()
    {
        if (current != null)
        {
            current.soyPrimero();
            circuito.moduloPrimero = current;
            circuito.TransformModulos();

            foreach (Modulo m in circuito.modulos)
            {
                m.selecPrimero = false;
            }
        }
        else
        {
            Debug.Log("No ha elegido un primero");
        }
       
    }

    private void PantallaElegirPrimero()
    {
        if (circuito.CircuitoListo())
        {
            circuito.SetInteractuable(false);
            rotar.gameObject.SetActive(false);
            Recta.gameObject.SetActive(false);
            Chicanne.gameObject.SetActive(false);
            Vuelta.gameObject.SetActive(false);
            ZigZag.gameObject.SetActive(false);
            Abierta.gameObject.SetActive(false);
            Cerrada.gameObject.SetActive(false);
            remove.gameObject.SetActive(false);
            listoConstruir.gameObject.SetActive(false);
            listoPrimero.gameObject.SetActive(true);

            foreach (Modulo m in circuito.modulos)
            {
                m.selecPrimero = true;
            }
        }
        else
        {
            Debug.Log("Circuito no cerrado");
        }
    }
}
