using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarreraController : MonoBehaviour
{
    //Aquí se controlarán las posiciones y el progreso de la carrera 

    //Auxiliar, borrar luego

    public const int N_PLAYERS = 4;

    //References

    public TimeController times;
    public Circuito circuito;
    public GameObject tiempoSalida;
    public Text tiemposJugador, numVuelta;
    //Variables
    [HideInInspector]
    public int contCochesAcabados = 0;

    private int vueltaMasActual=0;

   
    public void EmpezarCarrera()
    {
        circuito = FindObjectOfType<Circuito>();
        numVuelta.text = "1/" + circuito.numVueltas;

        StartCoroutine(Empezar());
    }

    public void InicioCarrera()
    {
        SeleccionadorCamara sc = FindObjectOfType<SeleccionadorCamara>();
        if (sc != null)
        {
            if (sc.seleccionador != null)
            {
                sc.seleccionador.gameObject.SetActive(true);
            }
        }
        circuito.Construir();
        circuito.IniciarCarrera();
        times.InicioTiempos();
        UIManagerCarrera ui = FindObjectOfType<UIManagerCarrera>();

        if (ui.minMaxController != null)
        {
             ui.minMaxController.enabled = true;
            FindObjectOfType<CameraController>().ComenzarCarrera(ui.myCar);
        }

        if(InformacionPersistente.singleton.nivelRitmoPropio >= 0)
        {
            circuito.pilotos[0].GetComponent<IAMoves>().nivelRitmo = InformacionPersistente.singleton.nivelRitmoPropio;
        }

        vueltaMasActual = 0;
    }

    IEnumerator Empezar()
    {
        SoundManager.singleton.EjecutarSonido(SONIDO.CUENTATRAS);
        if(FindObjectOfType<SeleccionadorCamara>()!=null)
            FindObjectOfType<SeleccionadorCamara>().AddCoches();
        tiempoSalida.SetActive(true);
        
        for(int i = 3; i >= 1; i--)
        {
            tiempoSalida.GetComponent<Text>().text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        tiempoSalida.SetActive(false);
        
        InicioCarrera();
    }

    public void UpdateCarrera(int ID,int vuelta)
    {
        if (vuelta < circuito.numVueltas)
        {

            if (vueltaMasActual < vuelta)
            {
                vueltaMasActual = vuelta;
                
            }
            if (ID == 0)
            {
                numVuelta.text = (vuelta+2) + "/" + circuito.numVueltas;
            }
            string tiempos= times.UpdateVuelta(ID,vuelta);

            if(ID == 0)
            {
                tiemposJugador.text = tiempos;
            }
        
            if(vuelta >= circuito.numVueltas-1)
            {
                contCochesAcabados++;
                if (ID == 0)
                {
                    FindObjectOfType<Constructor>().CameraFuncionando(FindObjectOfType<CameraController>());
                }
                if(contCochesAcabados>=N_PLAYERS)
                    FinCarrera();
            }
        }
    }
   
    public void FinCarrera()
    {
 
        //string[] clasFinal = new string[N_PLAYERS];
        //DarPuntos(clasFinal);
        FindObjectOfType<UIManagerCarrera>().SetPosiciones();
    }

    //public void DarPuntos(string [] s)
    //{
    //    int[] puntos;
    //}

}
