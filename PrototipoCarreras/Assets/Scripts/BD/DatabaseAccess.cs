using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using UnityEngine.UI;

public class DatabaseAccess : MonoBehaviour
{

    private string pathSave = "https://constellatrix-27332-default-rtdb.europe-west1.firebasedatabase.app/Circuitos/.json";
    private string pathLoad = "https://constellatrix-27332-default-rtdb.europe-west1.firebasedatabase.app/Circuitos.json?print=pretty'";
   // private string pathSave = "https://constelatrix-default-rtdb.europe-west1.firebasedatabase.app/Circuitos/.json";
    //private string pathLoad = "https://constelatrix-default-rtdb.europe-west1.firebasedatabase.app/Circuitos.json?print=pretty'";


    public GameObject popUp;
    public Text codigo;
    public Text nombreCircuito;


    
    void Start()
    {
        //SaveCircuitToDataBase("aquello");
        //GetCircuitoFromDataBase("-MQ_lLjAC1VfctaEM6BR");
        //GetCircuitoFromDataBaseRandom();
    }

   public async void SaveCircuitToDataBase(string order,string name){
       DatosCircuitos nuevoCircuito = new DatosCircuitos();
       nuevoCircuito.order = order;
       nuevoCircuito.name = name;
       RestClient.Post(pathSave, nuevoCircuito).Then(res =>{
            RestClient.Get(pathLoad).Then(response =>{
            SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(response.Text);
            string keyActual = "";
            foreach (var kvp in data)
            {
                if(InformacionPersistente.singleton.nombreUsuario.Equals(data[kvp.Key]["creator"])){
                    keyActual = kvp.Key;
                }
                
           }

           InformacionPersistente.singleton.codigoGuardado = keyActual;

           codigo.text = InformacionPersistente.singleton.codigoGuardado;
           nombreCircuito.text = data[keyActual]["name"];

           Debug.Log(codigo.text);
           
        });
       });
        Debug.Log("Datos Subidos");
        popUp.SetActive(true);

        

   }

   public async void GetCircuitoFromDataBaseByName(string name){
       RestClient.Get(pathLoad).Then(response =>
        {
            //Debug.Log(response.Text);
            SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(response.Text);
            
            foreach (var kvp in data)
            {
                if(name.Equals(kvp.Key)){
                    Debug.Log(data[kvp.Key]["order"]); 
                    InformacionPersistente.singleton.DATA_BD = data[name]["order"];
                    InformacionPersistente.singleton.nombreCircuitoActual = data[name]["name"];
                }
           }


           

        });
   }

    //public async void GetCircuitoFromDataBaseRandom(Constructor mine,UIManagerCarrera manager){
    //    RestClient.Get(pathLoad).Then(response =>
    //    {
    //        int numberOfItems = 0;
    //        SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(response.Text);

    //        foreach(var kvp in data){
    //            numberOfItems++;
    //        }

    //        int randomNumber = Random.Range(0,(numberOfItems));
    //        Debug.Log(randomNumber);
    //        Debug.Log(data[randomNumber]["order"]);
    //       // mine.ConstruirCircuitoDesdeBD(data[randomNumber]["order"],manager);
    //    });
    //}
    public async void GetCircuitoFromDataBaseRandom()
    {
       
        RestClient.Get(pathLoad).Then(response =>
        {
            int numberOfItems = 0;
          
            SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(response.Text);
           
            foreach (var kvp in data)
            {
                numberOfItems++;
            }

            int randomNumber = Random.Range(0, (numberOfItems ));
            Debug.Log(randomNumber);
        
            Debug.Log(data[randomNumber]["order"]);
            InformacionPersistente.singleton.DATA_BD = data[randomNumber]["order"];
            InformacionPersistente.singleton.nombreCircuitoActual = data[randomNumber]["name"];
           // mine.ConstruirCircuitoDesdeBD(data[randomNumber]["order"], dc);
        });
    }
    public async void GetCircuitoFromDataBaseModoCopa()
    {
        RestClient.Get(pathLoad).Then(response =>
        {
            int numberOfItems = 0;
            SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(response.Text);

            foreach (var kvp in data)
            {
                numberOfItems++;
            }
            for(int i=0; i < 4; i++)
            {
                int randomNumber = Random.Range(0, (numberOfItems));
                Debug.Log(randomNumber);
                Debug.Log(data[randomNumber]["order"]);
                InformacionPersistente.singleton.modoCopa[i]= Constructor.ParserFireBase(data[randomNumber]["order"]);
            }
           
           
        });
    }
    public async void GetCircuitoFromDataBaseModoTemporada(UIManagerMenus llamador)
    {

       

        RestClient.Get(pathLoad).Then(response =>
        {
            int numberOfItems = 0;
            SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(response.Text);

            foreach (var kvp in data)
            {
                numberOfItems++;
            }
            for (int i = 0; i < 4; i++)
            {
                int randomNumber = Random.Range(0, (numberOfItems));
       
                Debug.Log(data[randomNumber]["order"]);
                InformacionPersistente.singleton.modoManager[i] = Constructor.ParserFireBase(data[randomNumber]["order"]);
                InformacionPersistente.singleton.currentCircuito = InformacionPersistente.singleton.modoManager[0];
                llamador.circuitosListos = true;

                InformacionPersistente.singleton.nombreCircuitoTemporada[i] = data[randomNumber]["name"];
                
            }


        });
    }
    public async void GetCircuitoFromDataBaseModoCopa(UIManagerMenus llamador)
    {
        RestClient.Get(pathLoad).Then(response =>
        {
            int numberOfItems = 0;
            SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(response.Text);

            foreach (var kvp in data)
            {
                numberOfItems++;
            }
            for (int i = 0; i < 4; i++)
            {
                int randomNumber = Random.Range(0, (numberOfItems));

                Debug.Log(data[randomNumber]["order"]);
                InformacionPersistente.singleton.modoCopa[i] = Constructor.ParserFireBase(data[randomNumber]["order"]);
                InformacionPersistente.singleton.currentCircuito = InformacionPersistente.singleton.modoCopa[0];
                llamador.circuitosListos = true;
            }


        });
    }
    //public async void PRUEBA(Constructor mine, UIManagerCarrera manager)
    //{
    //    Debug.Log("antes del get");
    //    RestClient.Get(pathLoad).Then(response =>
    //    {
    //        Debug.Log("hola");
    //        int numberOfItems = 0;
    //        SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(response.Text);
    //        Debug.Log("Despues del parser");
    //        //foreach (var kvp in data)
    //        //{
    //        //    numberOfItems++;
    //        //}

    //        //int randomNumber = Random.Range(0, (numberOfItems));
    //        //Debug.Log(randomNumber);
    //        //Debug.Log(data[randomNumber]["order"]);
    //        mine.ConstruirCircuitoDesdeBD(data[0]["order"], manager);
    //        Debug.Log("Despues del construir" +
    //            "");
    //    });
    //}


    public void coppyToClipBoard(){

        GUIUtility.systemCopyBuffer =   InformacionPersistente.singleton.codigoGuardado;

        Debug.Log(GUIUtility.systemCopyBuffer);
        Debug.Log("HOLA");
    }

}



