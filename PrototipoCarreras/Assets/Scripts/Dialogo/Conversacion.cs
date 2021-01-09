
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Conver
{
    public string conver;
    public bool enUso = false;
}

[CreateAssetMenu(fileName = "NewConver", menuName = "ConverSystem/Conversacion", order = 2)]
[System.Serializable]
public class Conversacion : ScriptableObject
{
    // Start is called before the first frame update


    //Digievolucion: Varias convers y strings con las claves de la gente que habla pa poner el sprite correspondiente

    public Conver[] conver;

    private Queue<string> currentConver = new Queue<string>();
    public string clave;
    private int cont = 0;

    public bool iniciado = false;

    public void resetear()
    {
        iniciado = false;
    }
    public void IniciaConver(int index, int chara)
    {

        int parts = (conver[index].conver.Length / chara);

        if (conver.Length % chara > 0)
        {
            parts++;
        }
        for (int i = 0; i < parts; i++)
        {

            if (i == parts - 1)
            {
                currentConver.Enqueue(conver[index].conver.Substring(i * chara));
            }
            else
            {
                currentConver.Enqueue(conver[index].conver.Substring(i * chara, chara));
            }

        }



    }
    public string GetConver(int chara)
    {
        if (!iniciado)
        {
            cont = 0;
            iniciado = true;

            IniciaConver(0, chara);

        }
        if ((currentConver.Count == 0) && (cont == conver.Length - 1))
        {
            Debug.Log(conver.Length);
            iniciado = false;
            cont = 0;
            return null;

        }
        if (currentConver.Count == 0)
        {
            cont++;
            IniciaConver(cont, chara);
        }
        return currentConver.Dequeue();


    }



}
