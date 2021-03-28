﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gota : MonoBehaviour
{
    public Collider col;
    public Rigidbody rigi;
    public bool emitida;
    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<Collider>();
        rigi = gameObject.GetComponent<Rigidbody>();
        col.enabled = false;
        rigi.isKinematic=true;
    }

    private void Update()
    {
        /*if (rigi.velocity == Vector3.zero) {
            rigi.isKinematic = true;
        }*/
    }

    public void pool_out() {
        transform.localPosition = Vector3.zero;
        emitida = false;
        col.enabled = false;
        rigi.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("vaso")) {
            col.enabled = true;
        }
    }
}
