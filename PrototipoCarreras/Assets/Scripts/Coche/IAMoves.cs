using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAMoves : MonoBehaviour
{
    // Start is called before the first frame update
    private Coche coche;
    public float porcentajeFallo =5;
    public float Ritmo = 4f;
    void Start()
    {
        coche = GetComponent<Coche>();

    }

    // Update is called once per frame
    void Update()
    {
        if (coche.iniciado)
        {

            coche.currentSpeed=CalcularVelocidad();
        }
    }
    private float CalcularVelocidad()
    {
        float umbral = coche.currentModulo.umbral;

        int fallo = Random.Range(0, 100);

        int porcentaje = Random.Range(0, 100);

        if (fallo > porcentajeFallo)
        {
            return umbral - Ritmo*(porcentaje/100);
        }
        else
        {
            return umbral + Ritmo * (porcentaje / 100);
        }
    }
}
