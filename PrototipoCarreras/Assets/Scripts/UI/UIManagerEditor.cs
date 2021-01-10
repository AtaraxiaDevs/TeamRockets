using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Gestiona la UI del editor, con botones para cada modulo, para rotarlos, para eliminarlos...
public class UIManagerEditor : MonoBehaviour
{
    //Referencias
    private Modulo m_current;
    public Modulo current 
    { 
        get 
        { 
            return m_current; 
        }
        set 
        {
            if (m_current != null)
            {
                m_current.Destacar(false);
            }
            m_current = value;
            if (m_current != null)
            {
                m_current.Destacar(true);
            }
      

        } 
    }
    public GameObject prefabRecta, prefabVuelta,prefabAbierta,prefabCerrada,prefabZigZag,prefabChicanne,prefabEspecial;
    public Circuito circuito;
    public Dropdown vueltas;
 

    //Referencias UI
    public Button rotar, listoPrimero, Recta, Vuelta, Abierta, Cerrada, ZigZag, Chicanne,Especial, remove,listoConstruir, save;

    #region Unity
    void Start()
    {
        rotar.onClick.AddListener(()=> SoundManager.singleton.EjecutarSonido(SONIDO.BOTON1));

        remove.onClick.AddListener(()=>SoundManager.singleton.EjecutarSonido(SONIDO.ERROR2));
        listoPrimero.onClick.AddListener(() => SoundManager.singleton.EjecutarSonido(SONIDO.BOTON1));
        listoConstruir.onClick.AddListener(() => SoundManager.singleton.EjecutarSonido(SONIDO.BOTON1));
        Recta.onClick.AddListener(() => SoundManager.singleton.EjecutarSonido(SONIDO.BOTON2));
        ZigZag.onClick.AddListener(() => SoundManager.singleton.EjecutarSonido(SONIDO.BOTON2));
        Abierta.onClick.AddListener(() => SoundManager.singleton.EjecutarSonido(SONIDO.BOTON2));
        Vuelta.onClick.AddListener(() => SoundManager.singleton.EjecutarSonido(SONIDO.BOTON2));
        Cerrada.onClick.AddListener(() => SoundManager.singleton.EjecutarSonido(SONIDO.BOTON2));
        Chicanne.onClick.AddListener(() => SoundManager.singleton.EjecutarSonido(SONIDO.BOTON2));
        Especial.onClick.AddListener(() => SoundManager.singleton.EjecutarSonido(SONIDO.BOTON2));


        SoundManager.singleton.EjecutarMusica(MUSICA.EDITOR);
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
        Especial.onClick.AddListener(() => CrearModulo(prefabEspecial));
        vueltas.onValueChanged.AddListener((value) => circuito.numVueltas = (value + 1) * 4);
       
    }
    #endregion
    #region Creacion Y Modificacion del circuito
    private void CrearModulo(GameObject prefab)
    {
        //Debemos poner un punto de spawn
        Vector3 posicion = new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z);

        GameObject nuevoModulo = Instantiate(prefab, posicion, Quaternion.identity);
    
        current = nuevoModulo.GetComponent<Modulo>();
   
        // nuevoModulo.transform.Rotate
        circuito.AddModulo(nuevoModulo.GetComponent<Modulo>());
    }
    #endregion
    #region Metodos Auxiliares

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
            save.gameObject.SetActive(true);
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
            
            current = null;
            vueltas.gameObject.SetActive(true);
            circuito.numVueltas = 4;
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
    #endregion





}
