using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emisor_liquido : MonoBehaviour
{
    public GameObject gota;
    public GameObject instance;
    public GameObject[] instances;
    public int instances_index;
    public float tiempo=0;
    public float frecuencia; //frecuencia en que se lanzan las gotas
    public float tamaño_gota;
    public float radio_lanzamiento;//cuanto va avariar la pocición de lanzamiento de la gota
    public int max_gotas;//número máximo de gotas
    public bool emitir;

    // Start is called before the first frame update
    void Start()
    {
        instances = new GameObject[max_gotas];
        emitir = true;
        instances_index = 0;
        LanzarGota();
        Invoke("detenerEmision", tiempo);
    }

    // Update is called once per frame
    void detenerEmision() {
        emitir = false;
    }

    public void LanzarGota() {
        instance=Instantiate(gota);
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
    }
}
