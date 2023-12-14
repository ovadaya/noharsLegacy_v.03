using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DatosEnemigos : MonoBehaviour
{
    public float danoEnemigo;
    public float vidaEnemigo;
    private float vidaActualEnemigo;
    public Slider barraVidaEnemigo;

    private GameObject jugador;
    private DatosJugador datoJugador;

    [SerializeField] private float tiempoEntreDano;
    private float tiempoSiguienteDano;

    private void Start()
    {
        vidaActualEnemigo = vidaEnemigo;
        jugador = GameObject.FindWithTag("Player");
        datoJugador = jugador.GetComponent<DatosJugador>();
    }

    private void Update()
    {
        tiempoSiguienteDano -= Time.deltaTime;
        barraVidaEnemigo.value = vidaActualEnemigo;
    }

    // CUANDO ESTEN LAS ANIMACIONES EL DAñO SE HARñ DESDE EL SCRIPT DEL JUGADOR

    private void OnTriggerStay(Collider other)
    {
        /*
        if (other.CompareTag("Player"))
        {
            jugador = GameObject.FindWithTag("Player");
            datoJugador = jugador.GetComponent<DatosJugador>();

            if (tiempoSiguienteDano <= 0 && datoJugador != null)
            {
                datoJugador.recibirDano(15);
                tiempoSiguienteDano = tiempoEntreDano;
            }
        }
        */

        if (other.CompareTag("ArmaPlayer"))
        {
            Debug.Log("He tocado un arma");
            float danio = datoJugador.danio;
            recibirDanio(danio);
        }
    }
    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            datoJugador = null;
        }
    }
    */

    public void recibirDanio(float danio)
    {
        vidaActualEnemigo -= danio;

        if (vidaActualEnemigo <= 0)
        {
            Destroy(gameObject);
        }
    }
}

