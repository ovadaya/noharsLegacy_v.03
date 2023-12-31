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

    public float rango;
    private GameObject armaPlayer;
    private BoxCollider armaPlayerCollider;

    private int numPocionesVida;
    private int numPocionesDanio;

    public GameObject lifePotionSign;
    public GameObject damagePotionSign;

    public int numLlaves;

    public TMPro.TextMeshProUGUI textoPocionesVida;
    public TMPro.TextMeshProUGUI textoPocionesDanio;
    public TMPro.TextMeshProUGUI textoLlaves;

    public GameObject panelGameOver;
    public Animator animator;

    private void Start()
    {
        vidaActual = vidaJugadorInicial;
        barraVidaJugador.value = vidaActual;
        numPocionesVida = 0;
        panelGameOver.SetActive(false);
        armaPlayer = GameObject.FindWithTag("ArmaPlayer");

        lifePotionSign.SetActive(false);
        damagePotionSign.SetActive(false);
    }

    private void Update()
    {
        barraVidaJugador.value = vidaActual;
        textoPocionesVida.text = numPocionesVida.ToString();
        textoPocionesDanio.text = numPocionesDanio.ToString();
        textoLlaves.text = numLlaves.ToString();

        if (Input.GetKeyDown(KeyCode.E))
        {
            usarPocionVida();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            usarPocionDanio();
        }
        if (Input.GetKeyDown(KeyCode.F) && !Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("IsAtacking", false);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsEmpujando", true);
        }
        if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("IsAtacking", true);
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsEmpujando", false);
            armaPlayerCollider = armaPlayer.GetComponent<BoxCollider>();
            armaPlayerCollider.enabled = true;
        }
    }

    public void PushearEnemigos()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("MeleeEnemy");

        foreach (GameObject enemigo in enemigos)
        {
            float distancia = Vector3.Distance(transform.position, enemigo.transform.position);
            if (distancia <= rango)
            {
                ComportamientoEnemigo comportamientoEnemigo = enemigo.GetComponent<ComportamientoEnemigo>();

                if (comportamientoEnemigo != null)
                {
                    comportamientoEnemigo.pushear();
                }
            }
        }
    }

    public void recibirDano(float dmg)
    {
        vidaActual -= dmg;

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
        if(numPocionesVida == 0) {
            textoPocionesVida.color = Color.white;
            numPocionesVida++;

            lifePotionSign.SetActive(true);
        }
    }

    public void addPocionDanio()
    {
        if(numPocionesDanio == 0) {
            textoPocionesDanio.color = Color.white;
            numPocionesDanio++;

            damagePotionSign.SetActive(true);
        }
    }

    public void addKey()
    {
        if(numLlaves == 0) numLlaves++;
    }

    private void restarPocionVida()
    {
        numPocionesVida--;

        lifePotionSign.SetActive(false);
    }

    private void restarPocionDanio()
    {
        numPocionesDanio--;

        damagePotionSign.SetActive(false);
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

    private void usarPocionDanio()
    {
        if (numPocionesDanio > 0)
        {
            restarPocionDanio();
            danio = danio * 2;
            StartCoroutine(EsperarYRestaurarDanio());
        }
        else
        {
            textoPocionesDanio.color = Color.red;
        }
    }

    IEnumerator EsperarYRestaurarDanio()
    {
        yield return new WaitForSeconds(2f);
        danio = danio / 2;
    }

    public void finalAniAtack()
    {
        animator.SetBool("IsAtacking", false);
        armaPlayerCollider = armaPlayer.GetComponent<BoxCollider>();
        armaPlayerCollider.enabled = false;
    }

    public void finalAniJump()
    {
        animator.SetBool("IsJumping", false);
    }

    public void finalAniPushear()
    {
        Debug.Log("Llamada a la funcion");
        animator.SetBool("IsEmpujando", false);
    }
}

