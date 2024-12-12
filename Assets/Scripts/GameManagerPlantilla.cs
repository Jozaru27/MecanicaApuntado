using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameObject numBalasText;
    static int numBalas = 0;

    void Start()
    {
        // Buscar el GO del texto
        numBalasText = GameObject.Find("TextoBalas");
    }

    void Update()
    {        
        // De momento nada
    }

    static public void ResetearBalas()
    {
        // poner el número de balas a 0 y cambiar el texto 
        numBalas = 0;
        TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
        textoTMP1.text = "Balas: " + numBalas.ToString();
    }

    static public void IncNumBalas()
    {
        numBalas++;
        TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
        textoTMP1.text = "Balas: " + numBalas.ToString();
    }

    static public void DecNumBalas()
    {

    }
}
