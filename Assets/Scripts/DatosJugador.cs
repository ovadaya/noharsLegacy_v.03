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
    public float da�o;

    private GameObject armaPlayer;
    private BoxCollider armaPlayerCollider;

    private int numPocionesVida;
    private int numPocionesDa�o;

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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            usarPocionDa�o();
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

    public void addPocionDa�o()
    {
        //textoPocionesDa�o.color = Color.white;
        numPocionesDa�o++;
    }

    private void restarPocionVida()
    {
        numPocionesVida--;
    }

    private void restarPocionDa�o()
    {
        numPocionesDa�o--;
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

    private void usarPocionDa�o()
    {
        if (numPocionesDa�o > 0)
        {
            restarPocionDa�o();
            da�o = da�o * 2;
            StartCoroutine(EsperarYRestaurarDa�o());
        }
        else
        {
            textoPocionesVida.color = Color.red;
        }
    }

    IEnumerator EsperarYRestaurarDa�o()
    {
        yield return new WaitForSeconds(2f);
        da�o = da�o / 2;
    }

    public void finalAniAtack()
    {
        animator.SetBool("IsAtacking", false);
        armaPlayerCollider = armaPlayer.GetComponent<BoxCollider>();
        armaPlayerCollider.enabled = false;
    }
}

