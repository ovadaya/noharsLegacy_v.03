using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cofre : MonoBehaviour
{
    public Animator ani;
    private BoxCollider cubo;
    private CapsuleCollider capsula;
    [SerializeField] private AudioClip sonido;

    public GameObject key;
    private GameObject jugador;
    private DatosJugador datoJugador;


    void Start()
    {
        ani.SetBool("abrirse", false);
        capsula = this.GetComponent<CapsuleCollider>();
        cubo = this.GetComponent<BoxCollider>();
        jugador = GameObject.FindWithTag("Player");
        datoJugador = jugador.GetComponent<DatosJugador>();
    }

    void Update()
    {
        if (comprobarColliders())
        {
            ani.SetBool("abrirse", true);
            cubo.isTrigger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && comprobarColliders())
        {
            controladorSonidos.Instance.EjecutarSonido(sonido);
            key.SetActive(false);
            datoJugador.addKey();
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
