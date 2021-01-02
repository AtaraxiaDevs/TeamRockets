 using MongoDB.Bson;
 using MongoDB.Driver;
 using MongoDB.Bson.Serialization.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseAccess : MonoBehaviour
{

    MongoClient client = new MongoClient("mongodb+srv://AtaraziaDevs:webyrs2020@cluster0.3sf9z.mongodb.net/<dbname>?retryWrites=true&w=majority");
    IMongoDatabase database;
    IMongoCollection<BsonDocument> collection;
    void Start()
    {
        database = client.GetDatabase("ConstelatrixDB");
        collection = database.GetCollection<BsonDocument>("Circuitos");


    }

   public async void SaveCircuitToDataBase(){
        //¿Cómo vamos a rellenarlo?
        var document = new BsonDocument {{"highScore" , 200}};
        collection.InsertOne(document);


   }

   public async void GetCircuitoFromDataBase(string busqueda){
        //1- Crear query de filtrado
        //2- Pasarlo a un find y recoger el primero que encontremos.
        //var filter = Builders<BsonDocument>.Filter.Eq("keyName", busqueda);
        //var circuitoSelecionado = collection.Find(filter).FirstOrDefault();
        //Console.WriteLine(circuitoSeleccionado.ToString());

       // return "Hola";
   }
}

public class CircuitoData{
    //public string keyName {get;set;}
    //public string order {get;set}
    //public float bestTime{get;set}
    //public string creator {get;set}
}
