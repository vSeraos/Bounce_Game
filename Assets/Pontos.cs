using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Pontos : MonoBehaviour {
    public float Points;
    public float Segundos;
    bool Ligadas;
    public Text PointsText;
    public Text Cronometro;

    public Text Main;

    public float PontuacaoTotal;

    GameObject[] Cubos;

    bool Terminou;

    bool TudoLigado;
    // Use this for initialization
    void Start () {

        Main.text = "";
        Points = 0;
        Segundos = 100;
        PlayerPrefs.SetFloat("Pontos", 0);
        InvokeRepeating("DecValue", 1, 1);

        InvokeRepeating("Comemora", 1, 0.5f);

        Cubos = GameObject.FindGameObjectsWithTag("Cubos");

        foreach(GameObject Cubo in Cubos)
        {
            PontuacaoTotal = PontuacaoTotal + 100;
        }

    }
	
	// Update is called once per frame
	void Update () {
        PointsText.text = "Pontos: " + PlayerPrefs.GetFloat("Pontos");
        Points= PlayerPrefs.GetFloat("Pontos");
        Cronometro.text ="Tempo: "+ Segundos.ToString();
        

        if(Segundos<=0)
        {
            Debug.Log("Tempo Acabado");
            Main.text = "Time is Over";
            StartCoroutine(LoadLevelAfterDelay(3));
        }

        if (Points>=PontuacaoTotal)
        {
            Debug.Log("Parabens");
            Terminou = true;
            Main.text = "Congratulations";
            StartCoroutine(LoadLevelAfterDelay(3));
        }
	}

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   

    void DecValue()
    {
        Segundos=Segundos-1;


        if(Ligadas)
        {
            foreach (GameObject Luz in GameObject.FindGameObjectsWithTag("Luzes"))
            {
                Luz.GetComponent<Light>().intensity = 0;

            }
            Ligadas = false;
        }
        else
        {
            foreach (GameObject Luz in GameObject.FindGameObjectsWithTag("Luzes"))
            {
                Luz.GetComponent<Light>().intensity = 0;

            }
            Ligadas = true;
        }

    }

    void Comemora()
    {
        if(Terminou)
        {
            if(TudoLigado==false)
            {
                foreach (GameObject Luz in GameObject.FindGameObjectsWithTag("Luzes"))
                {
                    Luz.GetComponent<Light>().intensity = 2;
                    TudoLigado = true;
                }
            }
            else
            {
                foreach (GameObject Luz in GameObject.FindGameObjectsWithTag("Luzes"))
                {
                    Luz.GetComponent<Light>().intensity = 0;
                    TudoLigado = false;
                }
            }

          

        }
       
    }
}
