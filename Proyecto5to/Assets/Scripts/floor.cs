using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager GM;
    private void OnCollisionEnter(Collision collision)
    {
        //aplicar penalización cuando una gota/ingrediente caiga al suelo
        if (collision.gameObject.layer== LayerMask.NameToLayer("Gota")) {
            GM.score -= GM.spill_penalty;
        }
    }
}
