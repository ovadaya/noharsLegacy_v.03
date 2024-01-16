using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerSonidos : MonoBehaviour
{

    [SerializeField] private AudioClip sonido;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            controladorSonidos.Instance.EjecutarSonido(sonido);
        }
    }
}