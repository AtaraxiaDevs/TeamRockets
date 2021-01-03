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
        
        constructor.ConstruirCircuito("prueba");
        constructor.CameraFuncionando(camara);
     
        
           
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


}
