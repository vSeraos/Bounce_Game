using UnityEngine;
using System.Collections;

public class DragSphere : MonoBehaviour
{
    float distance = 10;
   

    Vector3 MousePosition1;
    Vector3 MousePosition2;

    GameObject Spawner;

    public LineRenderer Caminho;
  
     


    void Start()
    {
        Spawner = GameObject.FindGameObjectWithTag("Spawner");
    }

    private void OnMouseDown()
    {
        MousePosition1 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
      
    }
   

    void OnMouseUp()
    {
        MousePosition2 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Caminho.SetPosition(0, MousePosition1);
        Caminho.SetPosition(1, MousePosition2);
        this.GetComponent<Rigidbody>().useGravity = true;

        Vector3 result = MousePosition2 - MousePosition1;
        Debug.Log(result);
        this.GetComponent<Rigidbody>().AddForce(-result.y,0,result.x);



        StartCoroutine(Aguarda());
    }

    IEnumerator Aguarda()
    {
        print(Time.time);
        yield return new WaitForSeconds(0.5f);
        Spawner.GetComponent<SpawnBall>().OutraBola();
        print(Time.time);
    }

}