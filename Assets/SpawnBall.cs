using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour {
    public GameObject Ball;
    // Use this for initialization
    void Start () {
        Instantiate(Ball, this.transform.position, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OutraBola()
    {
      
        Instantiate(Ball, this.transform.position, Quaternion.identity);
       
    }

   
}
