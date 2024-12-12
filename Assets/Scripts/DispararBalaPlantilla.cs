using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DispararBala : MonoBehaviour
{
    GameObject posInicial;
    GameObject posFinal;
    GameObject canyon;

    public GameObject prefabBala;
    GameObject balaInstanciada;
    float distancia;
    public Material materialInstanciado; //necesario para poder cambiar el material del objeto
    public Transform objetoPadre; 
    
    // Al inicio del Script
    void Start(){
        posInicial = GameObject.Find("PuntoDeDisparo");         // De donde sale la bala
        posFinal = GameObject.Find("PuntoDeDisparoFinal");      // A donde apunta la bala
        canyon = GameObject.Find("Cuerpo");                     // Nombre del objeto del cañón (Cilindro en la escena)
    }

    // Actualiza el script cada frame
    void Update(){
        // Si la bala no es nula (o sea, que está instanciada)
        if (balaInstanciada != null) {
            // calcular la distancia entre la bala y el cañón
            distancia = Vector3.Distance(balaInstanciada.transform.position, canyon.transform.position);

            // Obtener el Renderer del cañón (Para acceder al material)
            Renderer renderer = canyon.GetComponent<Renderer>();

            // Cambiar el color del cañón si la bala está cerca
            if (distancia < 10f){
                renderer.material.color = Color.red;
            } else {
                renderer.material = materialInstanciado;
            }
        }
    }


    private void OnMouseDown(){
        // Instanciar el prefab de la bala en la posición inicial
        balaInstanciada = Instantiate(prefabBala, posInicial.transform.position, Quaternion.identity);

        balaInstanciada.name = "Bala"; // !!! 

        balaInstanciada.transform.SetParent(objetoPadre);

        // necesario para mantener las físicas
        Rigidbody rb = balaInstanciada.GetComponent<Rigidbody>();
        
        // Calcular la dirección del disparo (restar posicion inicial al final)
        Vector3 direccion = (posFinal.transform.position - posInicial.transform.position).normalized;

        // fuerza
        rb.AddForce(direccion * 50f, ForceMode.Impulse);

        // avisar al incrementor de balas
        GameManager.IncNumBalas();
    }

    // private void OnCollisionEnter(Collision collision)
    // {
        
    // }

}
