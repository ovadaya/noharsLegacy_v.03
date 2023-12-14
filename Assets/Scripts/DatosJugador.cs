using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DatosJugador : MonoBehaviour
{
    public float vidaJugadorInicial;
    private float vidaActual;
    public Slider barraVidaJugador;
    public float danio;

    private GameObject armaPlayer;
    private BoxCollider armaPlayerCollider;

    private int numPocionesVida;

    public TMPro.TextMeshProUGUI textoPocionesVida;

    public GameObject panelGameOver;
    public Animator animator;

    private void Start()
    {
        vidaActual = vidaJugadorInicial;
        barraVidaJugador.value = vidaActual;
        numPocionesVida = 0;
        panelGameOver.SetActive(false);
        armaPlayer = GameObject.FindWithTag("ArmaPlayer");
    }

    private void Update()
    {
        barraVidaJugador.value = vidaActual;
        textoPocionesVida.text = numPocionesVida.ToString();

        if (Input.GetKeyDown(KeyCode.E))
        {
            usarPocionVida();
        }
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("IsAtacking", true);
            armaPlayerCollider = armaPlayer.GetComponent<BoxCollider>();
            armaPlayerCollider.enabled = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("IsAtacking", false);
            armaPlayerCollider = armaPlayer.GetComponent<BoxCollider>();
            armaPlayerCollider.enabled = false;
        }
    }

    public void recibirDano(float dmg)
    {
        vidaActual -= dmg;
        Debug.Log(vidaActual);

        if (vidaActual <= 0)
        {
            panelGameOver.SetActive(true);
            animator.SetBool("NoLife", true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0f;
        }
    }

    public void curarVida(float cura)
    {
        if (vidaActual + cura > vidaJugadorInicial)
        {
            vidaActual = vidaJugadorInicial;
        }
        else
        {
            vidaActual += cura;
        }
    }

    public void addPocionVida()
    {
        textoPocionesVida.color = Color.white;
        numPocionesVida++;
    }

    private void restarPocionVida()
    {
        numPocionesVida--;
    }

    private void usarPocionVida()
    {
        if (vidaActual < vidaJugadorInicial)
        {
            if (numPocionesVida > 0)
            {
                curarVida(20);
                restarPocionVida();
            }
            else
            {
                textoPocionesVida.color = Color.red;

            }
        }
    }
    public void finalAniAtack()
    {
        animator.SetBool("IsAtacking", false);
        armaPlayerCollider = armaPlayer.GetComponent<BoxCollider>();
        armaPlayerCollider.enabled = false;
    }
}

