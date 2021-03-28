using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emisor_liquido : MonoBehaviour
{
    public bool emitir;
    public bool pause_emit;
    public bool stop_emit;
    public GameObject gota;
    public float tiempo=0;
    public float frecuencia; //frecuencia en que se lanzan las gotas
    public float tamaño_gota;
    public float radio_lanzamiento;//cuanto va avariar la pocición de lanzamiento de la gota
    public int max_gotas;//número máximo de gotas
    public bool pool_in;
    private int instances_index;
    public GameObject instance;
    public GameObject[] instances;

    private gota scr_gota;
    // Start is called before the first frame update
    void Start()
    {
        instances = new GameObject[max_gotas];
        instances = GameObject.FindGameObjectsWithTag("gota");
        emitir = false;
        pause_emit = false;
        instances_index = 0;
        Invoke("detenerEmision", tiempo);
    }

    // Update is called once per frame
    private void Update()
    {
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
        for (int i = 0; i < instances.Length;i++) {
            scr_gota = instances[i].GetComponent<gota>();
            if (scr_gota.emitida) {
                scr_gota.pool_out();
            }
        }
    }

    public void RelanzarGotas() {
        if (instances_index >= instances.Length || instances[instances_index] == null || pause_emit) {
            emitir = false;
            return;
        }
        scr_gota = instances[instances_index].GetComponent<gota>();
        if (scr_gota.emitida == false)
        {
            scr_gota.col.enabled = false;
            instances[instances_index].transform.position = new Vector3(Random.Range(-radio_lanzamiento, radio_lanzamiento) + transform.position.x, transform.position.y, Random.Range(-radio_lanzamiento, radio_lanzamiento) + transform.position.z);
            instances[instances_index].transform.localScale = Vector3.one * tamaño_gota;
            scr_gota.rigi.isKinematic = false;
            scr_gota.emitida = true;
            instances_index++;
            if (instances_index < instances.Length)
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
