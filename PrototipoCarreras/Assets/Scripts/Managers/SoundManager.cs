using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SONIDO
{
    ARRANCAR,
    BOTON1,
    BOTON2,
    CUENTATRAS,
    CURVAS,
    ERROR1,
    ERROR2
}
public enum MUSICA
{
    CARRERA,
    EDITOR,
    MENU

}
public class SoundManager : MonoBehaviour
{
    public AudioSource Sonido;
    public AudioSource Musica;

    public AudioClip[] Sonidos;
    public AudioClip[] Canciones;
    bool muteado= false;
   
    public static SoundManager singleton;

    public void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (singleton != this)
        {
            Destroy(gameObject);
        }
    }
    public void Mutear(bool value)
    {
        muteado = value;
        if (value)
        {
            Sonido.Stop();
            Musica.Stop();
        }
        else
        {
            Musica.Play();

        }


    }
    public void EjecutarSonido(SONIDO s)
    {
        if (!muteado)
        {
            Sonido.clip = Sonidos[(int)s];
            Sonido.Play();
        }
    
    }
    public void EjecutarSonido(SONIDO s,AudioSource propio)
    {
        if (!muteado)
        {
            propio.clip = Sonidos[(int)s];
            propio.Play();
        }
    }
    public void EjecutarMusica(MUSICA m)
    {
        if (!Musica.isPlaying || Musica.clip!= Canciones[(int)m])
        { 
            Musica.clip = Canciones[(int)m];
            if (!muteado)
            {
               
                Musica.Play();
            }

        }
        
    }
    public void PararMusica()
    {
        Sonido.Stop();

    }
    public void PararSonido()
    {
        Musica.Stop();
    }
    public void BajarVolumen( float value)
    {
        Musica.volume = value;
        Sonido.volume = value;
    }
}

