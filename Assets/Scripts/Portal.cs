using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private DatosJugador datoJugador;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            datoJugador = other.GetComponent<DatosJugador>();
            if(datoJugador.numLlaves > 0)
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }
}
