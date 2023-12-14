using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocionDaño : MonoBehaviour
{
    private DatosJugador datoJugador;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            datoJugador = other.GetComponent<DatosJugador>();
            datoJugador.addPocionDaño();
            Destroy(gameObject);
        }
    }
}