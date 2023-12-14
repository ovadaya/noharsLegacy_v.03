using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleAttackActivator : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("MeleWalk", false);
            anim.SetBool("MeleAttack", true);
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            anim.SetBool("MeleWalk", true);
            anim.SetBool("MeleAttack", false);
        }
    }
}
