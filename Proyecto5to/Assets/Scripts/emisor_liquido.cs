using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emisor_liquido : MonoBehaviour
{
    public GameObject gota;
    public GameObject instance;
    public float frecuencia; //frecuencia en que se lanzan las gotas
    public float tamaño_gota;
    public float radio_lanzamiento; //cuanto va avariar la pocición de lanzamiento de la gota

    // Start is called before the first frame update
    void Start()
    {
        LanzarGota();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LanzarGota() {
        instance=Instantiate(gota);
        instance.transform.position = new Vector3(Random.Range(-radio_lanzamiento,radio_lanzamiento),transform.position.y, Random.Range(-radio_lanzamiento, radio_lanzamiento));
        instance.transform.localScale = Vector3.one * tamaño_gota;
        CancelInvoke("LanzarGota");
        Invoke("LanzarGota", frecuencia);
    }
}
