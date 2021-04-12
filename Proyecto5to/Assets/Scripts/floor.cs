using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager GM;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer== LayerMask.NameToLayer("Gota")) {
            GM.score -= GM.spill_penalty;
        }
    }
}
