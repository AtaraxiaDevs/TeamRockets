using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

public class DatabaseAccess : MonoBehaviour
{

    
    void Start()
    {
        SaveCircuitToDataBase("aquello");
        //GetCircuitoFromDataBase("-MQ_lLjAC1VfctaEM6BR");
        GetCircuitoFromDataBaseRandom();
    }

   public async void SaveCircuitToDataBase(string order){
       DatosCircuitos nuevoCircuito = new DatosCircuitos();
       nuevoCircuito.order = order;
       RestClient.Post("https://constelatrixdb-default-rtdb.europe-west1.firebasedatabase.app/Circuitos/.json", nuevoCircuito);
        Debug.Log("Datos Subidos");
   }

   public async void GetCircuitoFromDataBaseByName(string name){
       RestClient.Get("https://constelatrixdb-default-rtdb.europe-west1.firebasedatabase.app/Circuitos.json?print=pretty'").Then(response =>
        {
            //Debug.Log(response.Text);
            SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(response.Text);
            
            foreach (var kvp in data)
            {
                if(name.Equals(kvp.Key))
                Debug.Log(data[kvp.Key]["order"]); 
           }
          

        });
   }

    public async void GetCircuitoFromDataBaseRandom(){
        RestClient.Get("https://constelatrixdb-default-rtdb.europe-west1.firebasedatabase.app/Circuitos.json?print=pretty'").Then(response =>
        {
            int numberOfItems = 0;
            SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(response.Text);

            foreach(var kvp in data){
                numberOfItems++;
            }

            int randomNumber = Random.Range(0,(numberOfItems-1));
            Debug.Log(randomNumber);
            Debug.Log(data[randomNumber]["order"]);
        });
    }

    
}



