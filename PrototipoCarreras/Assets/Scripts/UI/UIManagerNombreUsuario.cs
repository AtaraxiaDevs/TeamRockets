using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManagerNombreUsuario : MonoBehaviour
{
    public Text nombreUsuario;
    public UIManagerMenus managerMenus;
    void Start()
    {

    }

    // Update is called once per frame
    public void onClickNextScene()
    {
        string str = nombreUsuario.text.Replace(" ", string.Empty);
        if (!str.Equals("") && str != null)
        {
            InformacionPersistente.singleton.nombreUsuario = str;
            managerMenus.IrA("MainMenu");
        }
        else
        {
            Debug.Log("Error");
        }
    }
}
