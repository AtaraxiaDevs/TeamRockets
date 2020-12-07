using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circuito : MonoBehaviour
{
    //El circuito estará formado por una serie de módulos y de lineas que conformarán una unica linea
    // Start is called before the first frame update
    public Modulo[] modulos;
    public LineRenderer circuito;
    private int vertexcont = 0;
    public Coche prueba;
    public Transform prefabCircuito;
    public GameObject gameObjectCircuito;
    void Start()
    {
        circuito = new LineRenderer();
   
      
        Transform mytmp = Instantiate(prefabCircuito, transform);
        prueba = mytmp.GetComponentInChildren<Coche>();

        circuito = mytmp.GetComponent<LineRenderer>();
        vertexcont = 0;
     construir();
    }
    public void construir()
    {

        foreach (Modulo m in modulos)
        {
            Vector3[] pos = new Vector3[m.path.positionCount];
            m.path.GetPositions(pos);
            Transform t = m.path.transform;
            for(int i=m.path.positionCount-1; i >= 0; i--)
            {
                Vector3 point = t.TransformPoint(pos[i]);
                circuito.SetVertexCount(++vertexcont);
                circuito.SetPosition(vertexcont - 1, point);
            }
            //    foreach (Vector3 p in pos)
            //    {
            //        Vector3 point = t.TransformPoint(p);
            //        circuito.SetVertexCount(++vertexcont);
            //        circuito.SetPosition(vertexcont - 1, point);
            //    }
        }
        // StartCoroutine(pruebaI());

        prueba.init();
    }
    IEnumerator pruebaI()
    {
        foreach (Modulo m in modulos)
        {
            Vector3[] pos = new Vector3[m.path.positionCount];
            m.path.GetPositions(pos);
            Transform t = m.transform;
            foreach (Vector3 p in pos)
            {
                Vector3 point = t.TransformPoint(p);
                circuito.SetVertexCount(++vertexcont);
                circuito.SetPosition(vertexcont - 1, point);
                yield return new WaitForSeconds(1);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
