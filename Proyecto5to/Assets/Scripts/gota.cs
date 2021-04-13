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

        //setear la gota para que sea traspasable e invisible
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

    //quitar la gota del área de juego, y hacerla traspasabe e invisible
    public void pool_out() {
        mesh.enabled = false;
        transform.localPosition = Vector3.zero;
        emitida = false;
        col.enabled = false;
        rigi.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //hacer física la gota y darle un mejor efecto de expansión a las gotas cuando caen
        if (other.transform.CompareTag("vaso")|| other.transform.CompareTag("floor")|| other.transform.CompareTag("vaso_wall")) {
            col.enabled = true;
        }
    }
}
