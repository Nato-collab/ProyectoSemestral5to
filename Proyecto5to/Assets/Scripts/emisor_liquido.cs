using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emisor_liquido : MonoBehaviour
{
    public string tipo_liquido;//ej."cerveza"
    public int gotas_emitidas=0;
    public int gotas_emit_goal = 60;
    public bool emitir;
    public bool pause_emit;
    public bool stop_emit;
    public Color color_gota;
    public GameObject gota;
    public float tiempo=0;
    public float frecuencia; //frecuencia en que se lanzan las gotas
    public float tamaño_gota;
    public float radio_lanzamiento;//cuanto va avariar la pocición de emision de la gota
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
        gotas_emitidas = 0;
        //Invoke("detenerEmision", tiempo);
    }

    // Update is called once per frame
    private void Update()
    {
        instancesView = instances;//vista local del arreglo estático de gotas en el inspector
        if (emitir == true) {
            pause_emit = false;
            stop_emit = false;
            emitir = false;
            RelanzarGotas();//pool-in gotas existentes/instanciar gotas extra que se necesiten 
        }
        if (stop_emit) {
            detenerEmision();
        }
    }

    void detenerEmision() {
        emitir = false;
        gotas_emitidas = 0;
        instances_index = 0;
    }

    //sacar de el área de juego a todas las gotas
    public void pool_out() {
        for (int i = 0; i < instances.Count;i++) {
            scr_gota = instances[i].GetComponent<gota>();
            if (scr_gota.emitida) {
                scr_gota.pool_out();
            }
        }
    }

    public void RelanzarGotas() {
        //si se alcanzó en máximo de instancias de gotas posibles o se decidió pausar la emisión
        if (instances_index >= max_gotas || pause_emit) {
            emitir = false;//dejar de emitir
            return;
        }

        //detener emisión cuando se alcance el objetivo de un servicio de ese liquido
        if (gotas_emitidas >= gotas_emit_goal) {
            stop_emit = true;
        }

        //si no hay gotas disponibles en el arreglo, instanciar una gota
        if (instances[instances_index] == null) {

            instances[instances_index] = Instantiate(gota);
        }

        scr_gota = instances[instances_index].GetComponent<gota>();//obtener el script de la gota para sber si ya fué emitida
        if (scr_gota.emitida == false)
        {
            gotas_emitidas++;
            //hacer la gota traspasable y visible
            scr_gota.col.enabled = false;
            scr_gota.mesh.enabled = true;
            //
            scr_gota.transform.tag = tipo_liquido;//asignar el liquido al que pertenece la gota
            //asignar una pocición aleatoria desde donde se va a emitir la gota
            instances[instances_index].transform.position = new Vector3(Random.Range(-radio_lanzamiento, radio_lanzamiento) + transform.position.x, transform.position.y, Random.Range(-radio_lanzamiento, radio_lanzamiento) + transform.position.z);
            instances[instances_index].transform.localScale = Vector3.one * tamaño_gota;//asignar tamaño definido
            //cambiar el color del la gota dependiendo del líquido
            if (instances[instances_index].GetComponentInChildren<MeshRenderer>().material.GetColor("Color_A") != color_gota) {
                instances[instances_index].GetComponentInChildren<MeshRenderer>().material.SetColor("Color_A", color_gota);
            }
            //asignar valores físicos
            scr_gota.rigi.isKinematic = false;
            scr_gota.rigi.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            //
            scr_gota.emitida = true;//fue emitida
            instances_index++;

            //lanzar la siguente gota si es que es posible, con un delay definido
            if (instances_index < max_gotas)
            {
                Invoke("RelanzarGotas", frecuencia);
            }
        }
    }
}
