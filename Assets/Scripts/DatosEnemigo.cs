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

    private float tiempoUltimoDanio = 0f;
    public float tiempoEntreTicks = 1f;

    private void Start()
    {
        tiempoUltimoDanio = -tiempoEntreTicks;
        vidaActualEnemigo = vidaEnemigo;
        jugador = GameObject.FindWithTag("Player");
        datoJugador = jugador.GetComponent<DatosJugador>();
    }

    private void Update()
    {
        tiempoSiguienteDano -= 10;
        if(barraVidaEnemigo != null) {
            barraVidaEnemigo.value = vidaActualEnemigo;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ArmaPlayer"))
        {
            //if (Time.deltaTime - tiempoUltimoDanio >= tiempoEntreTicks)
            //{
                float danio = datoJugador.danio;
                recibirDanio(danio);
                tiempoUltimoDanio = Time.deltaTime;
            //}
        }
    }

    public void recibirDanio(float danio)
    {
        vidaActualEnemigo -= danio;

        if (vidaActualEnemigo <= 0)
        {
            Destroy(gameObject);
        }
    }
}

