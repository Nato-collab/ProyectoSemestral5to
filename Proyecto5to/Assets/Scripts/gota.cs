using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gota : MonoBehaviour
{
    Collider col;
    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<Collider>();
        col.enabled = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("vaso")) {
            col.enabled = true;
        }
    }
}
