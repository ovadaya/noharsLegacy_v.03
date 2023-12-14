using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocionSalud : MonoBehaviour
{
    public float curacion;
    private DatosJugador datoJugador;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            datoJugador = other.GetComponent<DatosJugador>();
            datoJugador.addPocionVida();
            Destroy(gameObject);
        }
    }
}
