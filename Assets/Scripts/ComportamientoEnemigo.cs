using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoEnemigo : MonoBehaviour
{
    [SerializeField] public Transform target;

    public float seguimientoRango = 10f;
    public float velocidadMovimiento = 5f;

    private Rigidbody rb;

    private bool isPushed = false;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanciaAlJugador = Vector3.Distance(transform.position, target.position);

        if (distanciaAlJugador < seguimientoRango && !isPushed)
        {
            Vector3 direccionAlJugador = (target.position - transform.position);
            direccionAlJugador.y = 0f;
            direccionAlJugador.Normalize();

            //transform.Translate(direccionAlJugador * velocidadMovimiento * Time.deltaTime, Space.World);
            rb.AddForce(direccionAlJugador * velocidadMovimiento * Time.deltaTime, ForceMode.Force);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && !isPushed)
            {
                isPushed = true;
                Vector3 direccionAlJugador = (target.position - transform.position);
                direccionAlJugador.y = 0f;
                direccionAlJugador.Normalize();
                rb.AddForce(-direccionAlJugador * 400f, ForceMode.Impulse);
            }
        }
        else
        {
            isPushed = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

        }
    }
}
