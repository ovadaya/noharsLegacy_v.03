using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreFinal : MonoBehaviour
{
    public Animator ani;
    private BoxCollider cubo;
    private CapsuleCollider capsula;
    [SerializeField] private AudioClip sonido;

    public GameObject key;
    private GameObject jugador;
    private DatosJugador datoJugador;

    private bool flag = true;
    private CapsuleCollider cofreCollider1;
    private BoxCollider cofreCollider2;

    void Start()
    {
        
        GameObject cofre = GameObject.FindGameObjectWithTag("Cofre");
        if (cofre != null)
        {
            cofreCollider1 = cofre.GetComponent<CapsuleCollider>();
            cofreCollider2 = cofre.GetComponent<BoxCollider>();
        }

        ani.SetBool("abrirse", false);
        capsula = this.GetComponent<CapsuleCollider>();
        cubo = this.GetComponent<BoxCollider>();
        jugador = GameObject.FindWithTag("Player");
        datoJugador = jugador.GetComponent<DatosJugador>();
    }

    void Update()
    {
        comprobarEnemigos();
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
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    private bool comprobarColliders()
    {
        bool res = false;
        if (capsula.isTrigger == true) res = true;
        if (cubo.isTrigger == true) res = true;
        return res;
    }

    private void comprobarEnemigos()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("MeleeEnemy");
        if (flag && enemigos.Length == 0) 
        {
            flag = false;

            cofreCollider1.isTrigger = true;
            cofreCollider2.isTrigger = true;
        }
    }
}
