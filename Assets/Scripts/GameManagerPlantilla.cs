using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Texto Balas En Escena
    static public GameObject numBalasText;
    static int numBalas = 0;

    // Texto Balas Disparadas
    static public GameObject numBalasDisparadasText;
    static int numBalasDisparadas = 0;

    // Diana
    GameObject[] posicionesDiana;
    GameObject   diana;
    public GameObject dianaPrefab;

    void Start()
    {
        // Buscar el GO del texto
        numBalasText = GameObject.Find("TextoBalas");
        numBalasText = GameObject.Find("TextoBalasDisparadas");

        // recupero los 5 elementos para la diana
        posicionesDiana = GameObject.FindGameObjectsWithTag("respawnDiana");

        // ESTA LLAMADA LA TENEIS QUE SUSTITUIR POR UN INSTANTIATE
        // diana = GameObject.Find("Diana");

        // MOVER LA ESFERA A UNA POSICI�N ALEATORIA
        //int tamanyoArrayDianas = posicionesDiana.Length; // tama�o = 5
        int numeroAleatorio    = Random.Range(0, posicionesDiana.Length); // rango de 0 a 4

        diana = Instantiate(dianaPrefab, posicionesDiana[numeroAleatorio].transform.position, Quaternion.Euler(0,90,0));

        GameObject dianaAleatoria = posicionesDiana[numeroAleatorio];
        diana.transform.position  = dianaAleatoria.transform.position;
    
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
        textoTMP1.text = "Balas en Escena: " + numBalas.ToString();
    }

    static public void IncNumBalas()
    {
        numBalas++;
        TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
        textoTMP1.text = "Balas en Escena: " + numBalas.ToString();
        numBalasDisparadas++;
    }

    static public void DecNumBalas()
    {
        numBalas--;
        TextMeshProUGUI textoTMP1 = numBalasText.GetComponent<TextMeshProUGUI>();
        textoTMP1.text = "Balas en Escena: " + numBalas.ToString();
    }

    public void MoverDiana()
    {
        //int numeroAleatorio = Random.Range(0, posicionesDiana.Length);
        //diana.transform.position = posicionesDiana[numeroAleatorio].transform.position;

        int numeroAleatorio = Random.Range(0, posicionesDiana.Length); // rango de 0 a 4

        Destroy(diana);

        diana = Instantiate(dianaPrefab, posicionesDiana[numeroAleatorio].transform.position, Quaternion.Euler(0, 90, 0));

        GameObject dianaAleatoria = posicionesDiana[numeroAleatorio];
        diana.transform.position = dianaAleatoria.transform.position;


    }
}
