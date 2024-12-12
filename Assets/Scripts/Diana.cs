using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diana : MonoBehaviour
{
    public Color colorCambioDiana; // Color tras impacto
    private int impactosDiana = 0;     // Contador de impactos
    private bool rotarDiana = false;   // Booleano para la rotación

    public float velocidadRotacion = 50f;

    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {
        if (rotarDiana)
        {
            transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
        }
    }

    // Método cuando ocurre una colisión
    private void OnCollisionEnter(Collision collision)
    {
        // YA NO - (opcional) verificar si el objeto que colisionó tiene la etiqueta "Bala" //tocó cambiar el colision detection a continuous
        // cada vez que las colisiones chocan, aumenta el número de impactos. con cada número hace una cosa.
        if (collision.gameObject.CompareTag("Bala")){
           
            impactosDiana++;

            if (impactosDiana == 1)
            {
                // Cambia el color de la Diana
                Renderer renderer = GetComponent<Renderer>();
                renderer.material.color = colorCambioDiana;
            }
            else if (impactosDiana == 2)
            {
                // Hace que la diana comience a rotar
                rotarDiana = true;
            }
            else if (impactosDiana >= 3)
            {
                // Destruye la diana tras el tercer impacto
                Destroy(gameObject);
            }
        }
    }
}
