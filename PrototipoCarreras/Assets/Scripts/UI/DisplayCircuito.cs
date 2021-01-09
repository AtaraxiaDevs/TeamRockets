using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCircuito : MonoBehaviour
{
    Constructor constructor;
    public CameraController camara;
    public Camera render;
    public Image display;
    private void Start()
    {
        constructor = FindObjectOfType<Constructor>();
        constructor.ConstruirCircuitoRandom(this);
       
    }

    private void Update()
    {
        var current = RenderTexture.active;
        RenderTexture.active = render.targetTexture;
        render.Render();
        Texture2D circuito = new Texture2D(render.targetTexture.width, render.targetTexture.height);
        circuito.ReadPixels(new Rect(0, 0, render.targetTexture.width, render.targetTexture.height),0,0);
        circuito.Apply();
        RenderTexture.active = current;
        display.sprite = Sprite.Create(circuito, new Rect(0, 0, render.targetTexture.width, render.targetTexture.height), new Vector2(0,0));
    }

    public void CircuitoCargado(Constructor c)
    {
        
        c.CameraFuncionando(camara);
    }
    public void OtroNuevo()
    {
        foreach(Modulo m in constructor.creado.modulos)
        {
            Destroy(m.gameObject);
        }
        Destroy(constructor.creado.gameObject);
        constructor.ConstruirCircuitoRandom(this);
    }

}
