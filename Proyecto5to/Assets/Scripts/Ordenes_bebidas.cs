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
        if (other.transform.CompareTag("vaso") && recibir_bebida)
        {
            recibir_bebida = false;
            vas = other.gameObject.GetComponent<vaso>();
            Invoke("bebidaCheck", recibe_time);
        }
    }

    private void bebidaCheck() {
        if (vas.drink_name == "mata toros" && vas.drink_name == order) {
            if (vas.whiskey_cantidad > 70)
            {
                GM.score += 70 - (vas.whiskey_cantidad - 70);
            }
            else {
                GM.score += 70 + (vas.whiskey_cantidad - 70);
            }
            if (vas.champagne_cantidad > 70)
            {
                GM.score += 70 - (vas.champagne_cantidad - 70);
            }
            else
            {
                GM.score += 70 + (vas.champagne_cantidad - 70);
            }
        }

        if (vas.drink_name == "")
        {
            GM.score -= penalty_bebida_vacia;
        }

        vas.Reset_vaso();
        recibir_bebida = true;
    }
}
