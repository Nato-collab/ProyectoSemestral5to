using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emisor_liquido : MonoBehaviour
{
    public bool emitir;
    public bool pause_emit;
    public bool stop_emit;
    public Color color_gota;
    public GameObject gota;
    public float tiempo=0;
    public float frecuencia; //frecuencia en que se lanzan las gotas
    public float tamaño_gota;
    public float radio_lanzamiento;//cuanto va avariar la pocición de lanzamiento de la gota
    public int max_gotas;//número máximo de gotas
    public bool pool_in;
    static public int instances_index;
    static public GameObject instance;
    static public List<GameObject> instances = new List<GameObject>();
    public List<GameObject> instancesView = new List<GameObject>();

    private gota scr_gota;
    // Start is called before the first frame update
    void Start()
    {
        instances = new List<GameObject>(GameObject.FindGameObjectsWithTag("gota"));
        for (int i = instances.Count; i < max_gotas; i++) {
            instances.Add(null);
        }
        emitir = false;
        pause_emit = false;
        instances_index = 0;
        //Invoke("detenerEmision", tiempo);
    }

    // Update is called once per frame
    private void Update()
    {
        instancesView = instances;
        if (emitir == true) {
            pause_emit = false;
            stop_emit = false;
            emitir = false;
            RelanzarGotas();
        }
        if (stop_emit) {
            detenerEmision();
        }
    }

    void detenerEmision() {
        emitir = false;
        instances_index = 0;
        pool_out();
    }

    public void pool_out() {
        for (int i = 0; i < instances.Count;i++) {
            scr_gota = instances[i].GetComponent<gota>();
            if (scr_gota.emitida) {
                scr_gota.pool_out();
            }
        }
    }

    public void RelanzarGotas() {
        if (instances_index >= max_gotas || pause_emit) {
            emitir = false;
            return;
        }
        print("pass");
        if (instances[instances_index] == null) {

            instances[instances_index] = Instantiate(gota);
        }

        scr_gota = instances[instances_index].GetComponent<gota>();
        if (scr_gota.emitida == false)
        {
            scr_gota.col.enabled = false;
            scr_gota.mesh.enabled = true;
            instances[instances_index].transform.position = new Vector3(Random.Range(-radio_lanzamiento, radio_lanzamiento) + transform.position.x, transform.position.y, Random.Range(-radio_lanzamiento, radio_lanzamiento) + transform.position.z);
            instances[instances_index].transform.localScale = Vector3.one * tamaño_gota;
            if (instances[instances_index].GetComponentInChildren<MeshRenderer>().material.GetColor("Color_A") != color_gota) {
                instances[instances_index].GetComponentInChildren<MeshRenderer>().material.SetColor("Color_A", color_gota);//cambiar el color del la gota dependiendo de la botella
            }
            scr_gota.rigi.isKinematic = false;
            scr_gota.rigi.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            scr_gota.emitida = true;
            instances_index++;
            if (instances_index < max_gotas)
            {
                Invoke("RelanzarGotas", frecuencia);
            }
        }
    }

    /*public void CrearGota() {
        instance=Instantiate(gota,transform);
        instance.transform.position = new Vector3(Random.Range(-radio_lanzamiento,radio_lanzamiento)+transform.position.x,transform.position.y, Random.Range(-radio_lanzamiento, radio_lanzamiento)+transform.position.z);
        instance.transform.localScale = Vector3.one * tamaño_gota;
        try
        {
            instances[instances_index] = instance;
        }
        catch
        {
            emitir = false;
            print("máximo de particulas alcanzado");
        }
        instances_index++;
        CancelInvoke("LanzarGota");
        if (emitir)
        {
            Invoke("LanzarGota", frecuencia);
        }
    }*/
}
