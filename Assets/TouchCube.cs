using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCube : MonoBehaviour {
    Light LuzInterior;
    bool Tocado;
	// Use this for initialization
	void Start () {
        LuzInterior = GetComponentInChildren<Light>();

        LuzInterior.intensity = 0;
        Tocado = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnCollisionEnter(Collision collision)
    {

        LuzInterior.intensity = 2;

        if (Tocado == false)
        {
            this.GetComponent<Renderer>().material.color = new Color(0.9f, 0.5f, 0.1f, 0.8f);

            float pontos = PlayerPrefs.GetFloat("Pontos");
            PlayerPrefs.SetFloat("Pontos", pontos + 100);
           
            Tocado = true;
        }


    }

    void OnCollisionExit(Collision collision)
    {
        LuzInterior.intensity = 1;
       
    }
}
