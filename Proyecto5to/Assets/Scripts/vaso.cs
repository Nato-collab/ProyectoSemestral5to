using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaso : MonoBehaviour
{
    public string drink_name;
    public int whiskey_cantidad;
    public int champagne_cantidad;
    public List<GameObject> whiskey;
    public List<GameObject> champagne;
    public Vector3 initial_pos;
    public emisor_liquido emisor;

    // Start is called before the first frame update
    private void Start()
    {
        drink_name="";
        initial_pos = transform.position;
    }

    private void Update()
    {
        //actualizar los vlaores de cantidad dependiendo de la cantidad de objetos en las listas
        if (whiskey_cantidad != whiskey.Count) {
            whiskey_cantidad = whiskey.Count;
        }
        if (champagne_cantidad != champagne.Count)
        {
            champagne_cantidad = champagne.Count;
        }
        
        checkForDrinks();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //agregar los ingredientes a la lista que pertenecen cuando enstán dentro del vaso
        if (collision.gameObject.CompareTag("whis")) {
            whiskey.Add(collision.gameObject);
            collision.transform.tag = "gota";
        }
        if (collision.gameObject.CompareTag("cham"))
        {
            champagne.Add(collision.gameObject);
            collision.transform.tag = "gota";
        }
    }

    /*private void OnCollisionExit(Collision collision)
    {
        //quitar los ingredientes a la lista que pertenecen cuando enstán fuera
        if (collision.gameObject.CompareTag("whis"))
        {
            whiskey.Remove(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("cham"))
        {
            champagne.Remove(collision.gameObject);
        }
    }*/

    //checar si se cumplen los requerimientos de ingredientes para hacer una bebida
    public void checkForDrinks() {
        if (whiskey_cantidad > 10 && champagne_cantidad > 10) {
            drink_name = "mata toros";
        }
    }

    public void Reset_vaso() {
        if (whiskey_cantidad > 0) {
            for (int i = 0; i < whiskey.Count; i++) {
                whiskey[i].GetComponent<gota>().pool_out();
            }
        }
        if (champagne_cantidad > 0)
        {
            for (int i = 0; i < champagne.Count; i++)
            {
                champagne[i].GetComponent<gota>().pool_out();
            }
        }
        emisor.pool_out();
        transform.position = initial_pos;
    }
}
