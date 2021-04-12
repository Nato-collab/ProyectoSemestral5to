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
    // Start is called before the first frame update

    private void Update()
    {
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
        if (collision.gameObject.CompareTag("whis")) {
            whiskey.Add(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("cham"))
        {
            champagne.Add(collision.gameObject);
        }
    }

    public void checkForDrinks() {
        if (whiskey_cantidad > 60 && champagne_cantidad > 60) {
            drink_name = "mata-toros";
        }
    }
}
