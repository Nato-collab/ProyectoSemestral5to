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
        if ((transform.rotation.eulerAngles.x > 70 && transform.rotation.eulerAngles.x < 290 ) || (transform.rotation.eulerAngles.z > 70 && transform.rotation.eulerAngles.z < 290))
        {
            if (emisor.gotas_emitidas < emisor.gotas_emit_goal)
            {
                if (emisor.color_gota != liquido_color)
                {
                    emisor.color_gota = liquido_color;
                }
                emisor.emitir = true;
            }
        }
        else {
            emisor.pause_emit = true;
            if (emisor.gotas_emitidas >= emisor.gotas_emit_goal) {
                emisor.gotas_emitidas = 0;
            }
        }
    }
}
