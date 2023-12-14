using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Efollow : MonoBehaviour
{
    [SerializeField] public Transform target;

    public float seguimientoRango = 10f; 
    public float velocidadMovimiento = 5f; 
    private DatosJugador datoJugador;

    private Rigidbody rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

        float distanciaAlJugador = Vector3.Distance(transform.position, target.position);

        if (distanciaAlJugador < seguimientoRango)
        {
            Vector3 direccionAlJugador = (target.position - transform.position);
            direccionAlJugador.y = 0f; 
            direccionAlJugador.Normalize();

            //transform.Translate(direccionAlJugador * velocidadMovimiento * Time.deltaTime, Space.World);
            rb.AddForce(direccionAlJugador * velocidadMovimiento * Time.deltaTime, ForceMode.Force);
            
        }
    }
}
