using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ordenes_bebidas : MonoBehaviour
{
    public vaso vas;
    public GameManager GM;
    public int penalty_bebida_vacia;
    public bool recibir_bebida;
    private float recibe_time=1f;
    public Text order_text;
    public string order;
    // Start is called before the first frame update
    void Start()
    {
        recibir_bebida = true;
    }

    // Update is called once per frame
    private void Update()
    {
        //mostrar que bebida va a preparar al jugador
        if ("Preparar: " + order != order_text.text) {
            order_text.text = "Preparar: " + order;
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("vaso")&&recibir_bebida) {
            recibir_bebida = false;
            vas = collision.gameObject.GetComponent<vaso>();
            Invoke("bebidaCheck", recibe_time);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        //cuando el vaso entra en el area de rivisión, se empiza a hacer el chequeo de los puntos ganados por preparar la bebida
        if (other.transform.CompareTag("vaso") && recibir_bebida)
        {
            recibir_bebida = false;
            vas = other.gameObject.GetComponent<vaso>();
            Invoke("bebidaCheck", recibe_time);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //cuando el vaso sale de la zona de revivsión, se cancela el chequeo de puntos
        if (other.transform.CompareTag("vaso"))
        {
            recibir_bebida = true;
            CancelInvoke("bebidaCheck");
        }
    }

    //revisión de puntos
    private void bebidaCheck() {
        if (vas.drink_name == "mata toros" && vas.drink_name == order) {
            if (vas.whiskey_cantidad > 70)//penalización si se pasó de cantidad
            {
                GM.score += 70 - (vas.whiskey_cantidad - 70);
            }
            else //penalización si le faltó cantidad
            {
                GM.score += 70 + (vas.whiskey_cantidad - 70);
            }

            if (vas.champagne_cantidad > 70)//penalización si se pasó de cantidad
            {
                GM.score += 70 - (vas.champagne_cantidad - 70);
            }
            else//penalización si le faltó cantidad
            {
                GM.score += 70 + (vas.champagne_cantidad - 70);
            }
        }

        if (vas.drink_name == "")//penalización si entrega un vaso sin bebida
        {
            GM.score -= penalty_bebida_vacia;
        }

        vas.Reset_vaso();//resetear la pocición y el contenido del vaso 
        recibir_bebida = true;
    }
}
