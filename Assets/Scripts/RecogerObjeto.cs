using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecogerObjeto : MonoBehaviour
{
    public float velocidadRotacion = 5f;
    public float distanciaRecogida = 3f;
    public float escalaTamanyo = 1.2f;

    private Vector3 escalaOriginal;
    private bool cercaDelObjeto = false;

    public Item item;

    private void Start()
    {
        escalaOriginal = transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cercaDelObjeto = true;
            AjustarTamaño();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cercaDelObjeto = false;
            RestaurarTamaño();
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime);

        if (cercaDelObjeto && Input.GetKeyDown(KeyCode.Q) && PuedeRecoger())
        {
            Recoger();
        }
    }

    void AjustarTamaño()
    {
        transform.localScale = escalaOriginal * escalaTamanyo;
    }

    void RestaurarTamaño()
    {
        transform.localScale = escalaOriginal;
    }

    bool PuedeRecoger()
    {
        Vector3 direccionAlObjeto = transform.position - Camera.main.transform.position;
        float angulo = Vector3.Angle(Camera.main.transform.forward, direccionAlObjeto);

        return (angulo < 45f && direccionAlObjeto.magnitude < distanciaRecogida);
    }

    void Recoger()
    {
        // Agrega el objeto al inventario del jugador
        if (item != null)
        {
            Inventario.AgregarItem(item);
        }

        // Desactiva el objeto o realiza otras acciones según tus necesidades
        gameObject.SetActive(false);
    }
}
