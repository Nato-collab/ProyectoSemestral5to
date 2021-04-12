using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botella : MonoBehaviour
{
    public emisor_liquido emisor;
    public Color liquido_color;
    // Start is called before the first frame update
    void Start()
    {
        emisor = gameObject.GetComponentInChildren<emisor_liquido>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si la botella está girada hacia la derecha, izquierda, adelante o atás ciertos grados.
        if ((transform.rotation.eulerAngles.x > 70 && transform.rotation.eulerAngles.x < 290 ) || (transform.rotation.eulerAngles.z > 70 && transform.rotation.eulerAngles.z < 290))
        {
            //hay gotas disponibles para emitir?
            if (emisor.gotas_emitidas < emisor.gotas_emit_goal)
            {
                if (emisor.color_gota != liquido_color)
                {
                    emisor.color_gota = liquido_color;//se le asigna el color que le correspponde al liquido si aún no se ha hecho
                }
                emisor.emitir = true;//Se emiten gotas
            }
        }
        //si no está girada de la forma ya descrita, se pausa la emisión
        else {
            emisor.pause_emit = true;
            //si se emitieron igual o más gotas de las que se pueden emitir al momento de regresar del giro
            if (emisor.gotas_emitidas >= emisor.gotas_emit_goal) {
                //se reinicia la cntidad de gotas para emitir
                emisor.gotas_emitidas = 0;
            }
        }
    }
}
