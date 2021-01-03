using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEditor : MonoBehaviour
{
    //input mouse 1
    Vector3 comienzo,centro;
    Camera main;
    bool moviendose;
    private void Start()
    {
        main = Camera.main;
        centro = new Vector3(Screen.width, 0, Screen.height);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            moviendose = true;
           
        }
        else if (Input.GetMouseButtonUp(1))
        {
            moviendose = false;
        }
        Debug.Log(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        if (moviendose)
        {

        }
        
    }
    private void OnMouseDown()
    {
        comienzo  =Input.mousePosition;
       // main.transform.position = new Vector3(comienzo.x, main.transform.position.y, comienzo.z);
    }
    private void OnMouseDrag()
    {
        //if(main.transform.position.x)
        Vector3 pos = main.ScreenToWorldPoint(comienzo-Input.mousePosition);
        Vector3 move = new Vector3(pos.x * 0.01f, 0, pos.y * 0.01f);
        main.transform.Translate(move, Space.World);
    }
    
}
