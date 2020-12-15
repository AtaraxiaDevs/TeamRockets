//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CreatorLine : MonoBehaviour
//{


//    public Transform drawingpref;
//    List<LineRenderer> lines;
//   // List<Recta> rectas;
//    Vector3 virtualpos;
//    Vector3 LastPosition;
//    LineRenderer current;

//    bool isDrawing = false;
//    bool seMueve = false;
//    float epsilon = 0.5f;
//    int vertexcont;
//    GameObject currentLine;
//    // Start is called before the first frame update
//    void Start()
//    {
//        lines = new List<LineRenderer>();
//        LastPosition = Vector2.zero;
        
//       // rectas = new List<Recta>();
//        virtualpos = Vector2.zero;

//    }

//    // Update is called once per f Debug.Log("x " + posMouse.x);rame
//    void Update()
//    {
//        Vector3 posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        virtualpos = new Vector3(posMouse.x, posMouse.y,10);
    

//        //if (!(((virtualpos.x >= LastPosition.x - epsilon) && (virtualpos.x <= LastPosition.x + epsilon)) && ((virtualpos.y >= LastPosition.y - epsilon) && (virtualpos.y <= LastPosition.y + epsilon))))
//        //{
//        //    seMueve = true;
//        //    LastPosition = virtualpos;
//        //}

//        //if ((isDrawing) && (seMueve))
//        //{
//        //    puntos.Add(new Point(virtualpos.x, virtualpos.y, -1));
//        //    //Debug.Log("añadido:" + Input.mousePosition.x + " " + Input.mousePosition.y);
//        //}


//        //movil--->mirar como detectar el touch primero
//        if (Input.GetMouseButtonDown(0))
//        {
//            isDrawing = true;
//            Transform mytmp = Instantiate(drawingpref, transform);
//            currentLine = mytmp.gameObject;
//            current = mytmp.GetComponent<LineRenderer>();
//            current.startWidth = 0.4f;
//            lines.Add(current);
//            vertexcont = 0;

//        }
//        if (Input.GetMouseButton(0) && isDrawing)
//        {
//            //if ((!(Mathf.Approximately(LastPosition.x, virtualpos.x) && Mathf.Approximately(LastPosition.y, virtualpos.y))))
//            //{
//            if (!(((virtualpos.x >= LastPosition.x - epsilon) && (virtualpos.x <= LastPosition.x + epsilon)) && ((virtualpos.y >= LastPosition.y - epsilon) && (virtualpos.y <= LastPosition.y + epsilon))&& ((virtualpos.z >= LastPosition.z - epsilon) && (virtualpos.z <= LastPosition.z + epsilon))))
//            {
//                //Recta last = null;
//                seMueve = true;
//                //if (vertexcont != 0)
//                //{
//                //    last = new Recta(LastPosition.x, LastPosition.y, virtualpos.x, virtualpos.y);
//                //    rectas.Add(last);



//                //}

//                current.SetVertexCount(++vertexcont);
//                current.SetPosition(vertexcont - 1, virtualpos);

//                LastPosition = virtualpos;

//                //if (last != null)
//                //{
//                //    if (LineIsClosed(last))
//                //    {
//                //        current.SetVertexCount(0);
//                //        rectas.Clear();
//                //        puntos.Clear();
//                //        Debug.Log("cerrada");
//                //        vertexcont = 0;
//                //    }

//                //}



//            }
//            else
//            {
//                seMueve = false;
//            }

//        }
//        if (Input.GetMouseButtonUp(0) && isDrawing)
//        {

//            isDrawing = false;
//            if (vertexcont != 0)
//            {
//                current.SetVertexCount(++vertexcont);
//                current.SetPosition(vertexcont - 1,current.GetPosition(0));
//                currentLine.GetComponentInChildren<Coche>().Init();
//                //current.SetVertexCount(0);
//                vertexcont = 0;
                

//            }
//        }
//    }
//}
