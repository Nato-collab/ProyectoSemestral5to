using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gota : MonoBehaviour
{
    public Collider col;
    public Rigidbody rigi;
    public bool emitida;
    public MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<Collider>();
        rigi = gameObject.GetComponent<Rigidbody>();
        mesh=GetComponentInChildren<MeshRenderer>();
        mesh.enabled = false;
        col.enabled = false;
        emitida = false;
        rigi.isKinematic=true;
        rigi.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    }

    private void Update()
    {
        /*if (rigi.velocity == Vector3.zero) {
            rigi.isKinematic = true;
        }*/
    }

    public void pool_out() {
        mesh.enabled = false;
        transform.localPosition = Vector3.zero;
        emitida = false;
        col.enabled = false;
        rigi.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("vaso")|| other.transform.CompareTag("floor")) {
            col.enabled = true;
        }
    }
}
