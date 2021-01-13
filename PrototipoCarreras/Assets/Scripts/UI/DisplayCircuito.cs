using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCircuito : MonoBehaviour
{
    Constructor constructor;
    public CameraController camara;

    public Camera render;
    public Image[] display;
    public InputField codigo;
    private bool esperandoCircuitoFlag= false, importandoCircuito= false;
    public bool UISelector;

    public GameObject managerUI;

    private void Start()
    {
        camara = FindObjectOfType<CameraController>();
        constructor = FindObjectOfType<Constructor>();
        if (UISelector)
        {
            constructor.ConstruirCircuito();
            esperandoCircuitoFlag = true;

        }
        else
        {
            constructor.DataToCircuito(InformacionPersistente.singleton.currentCircuito);
            constructor.CameraFuncionando(camara);
        }
        //camara = FindObjectOfType<CameraController>();
    }

    private void Update()
    {
        if (esperandoCircuitoFlag)
        {
            if (!InformacionPersistente.singleton.DATA_BD.Equals(""))
            {
                esperandoCircuitoFlag = false;
                if (importandoCircuito)
                {
                    importandoCircuito = false;
                    if (InformacionPersistente.singleton.DATA_BD.Equals("NO")){
                        InformacionPersistente.singleton.DATA_BD = "";
                        //popup
                        return;
                    }

                }
                LimpiarCircuito();
                constructor.ConstruirCircuitoDesdeBD(InformacionPersistente.singleton.DATA_BD, this);
                managerUI.GetComponent<UIManagerElegirCircuito>().cambiarNombre();

                InformacionPersistente.singleton.DATA_BD = "";
             
              
            }
        }

        //if (!InformacionPersistente.singleton.esMovil)
        //{
            var current = RenderTexture.active;
            RenderTexture.active = render.targetTexture;
            render.Render();
            Texture2D circuito = new Texture2D(render.targetTexture.width, render.targetTexture.height);
            circuito.ReadPixels(new Rect(0, 0, render.targetTexture.width, render.targetTexture.height), 0, 0);
            circuito.Apply();
            RenderTexture.active = current;
            foreach (Image i in display)
            {

                i.sprite = Sprite.Create(circuito, new Rect(0, 0, render.targetTexture.width, render.targetTexture.height), new Vector2(0, 0));
            }
        
        MostrarCircuito();
    }
    private void MostrarCircuito()
    {
        var current = RenderTexture.active;
        RenderTexture.active = render.targetTexture;
        render.Render();
        Texture2D circuito = new Texture2D(render.targetTexture.width, render.targetTexture.height);
        circuito.ReadPixels(new Rect(0, 0, render.targetTexture.width, render.targetTexture.height), 0, 0);
        circuito.Apply();
        RenderTexture.active = current;
        foreach (Image i in display)
        {

            i.sprite = Sprite.Create(circuito, new Rect(0, 0, render.targetTexture.width, render.targetTexture.height), new Vector2(0, 0));
        }
    }

    public void CircuitoCargado(Constructor c)
    {
        
        c.CameraFuncionando(camara);
    }
    public void OtroNuevo()
    {
        
       
        constructor.ConstruirCircuito();
        esperandoCircuitoFlag = true;
    }
    private void LimpiarCircuito()
    {
        if (constructor.creado != null)
        {
            foreach (Modulo m in constructor.creado.modulos)
            {
                Destroy(m.gameObject);
            }
            Destroy(constructor.creado.gameObject);
            constructor.creado = null;

        }
    }
    public void GenerarPorCodigo()
    {
        string code = codigo.text.Trim();
        if (!code.Equals(""))
        {
           
            constructor.ImportarCircuito(code);
            esperandoCircuitoFlag = true;
            importandoCircuito = true;
        }
        else
        {
            //POPUP
        }
      
    }

}
