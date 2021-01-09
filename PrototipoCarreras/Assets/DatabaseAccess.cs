﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

public class DatabaseAccess : MonoBehaviour
{


    private string pathSave = "https://constellatrix-27332-default-rtdb.europe-west1.firebasedatabase.app/Circuitos/.json";
    private string pathLoad = "https://constellatrix-27332-default-rtdb.europe-west1.firebasedatabase.app/Circuitos.json?print=pretty'";
    void Start()
    {
        //SaveCircuitToDataBase("aquello");
        //GetCircuitoFromDataBase("-MQ_lLjAC1VfctaEM6BR");
        //GetCircuitoFromDataBaseRandom();
    }

   public async void SaveCircuitToDataBase(string order){
       DatosCircuitos nuevoCircuito = new DatosCircuitos();
       nuevoCircuito.order = order;
       RestClient.Post(pathSave, nuevoCircuito);
        Debug.Log("Datos Subidos");
   }

   public async void GetCircuitoFromDataBaseByName(string name, Constructor mine, UIManagerCarrera manager){
       RestClient.Get(pathLoad).Then(response =>
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

    public async void GetCircuitoFromDataBaseRandom(Constructor mine,UIManagerCarrera manager){
        RestClient.Get(pathLoad).Then(response =>
        {
            int numberOfItems = 0;
            SimpleJSON.JSONNode data = SimpleJSON.JSON.Parse(response.Text);

            foreach(var kvp in data){
                numberOfItems++;
            }

            int randomNumber = Random.Range(0,(numberOfItems));
            Debug.Log(randomNumber);
            Debug.Log(data[randomNumber]["order"]);
            mine.ConstruirCircuitoDesdeBD(data[randomNumber]["order"],manager);
        });
    }
    public async void GetCircuitoFromDataBaseRandom(Constructor mine, DisplayCircuito dc)
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
            mine.ConstruirCircuitoDesdeBD(data[randomNumber]["order"], dc);
        });
    }

}



