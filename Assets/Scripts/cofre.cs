using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cofre : MonoBehaviour
{
    public Animator ani;
    private BoxCollider cubo;
    private CapsuleCollider capsula;

    void Start()
    {
        ani.SetBool("abrirse", false);
        capsula = this.GetComponent<CapsuleCollider>();
        cubo = this.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && comprobarColliders())
        {
            ani.SetBool("abrirse", true);
            cubo.isTrigger = false;
        }
    }

    private bool comprobarColliders()
    {
        bool res = false;
        if(capsula.isTrigger == true) res = true;
        if(cubo.isTrigger == true) res = true;   
        return res;
    }
}
