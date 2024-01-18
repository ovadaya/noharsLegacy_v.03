using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oleadas : MonoBehaviour
{
    public enum wState {siguiente, max};
    public wState wave = wState.siguiente;

    private float timeout;
    
    public GameObject[] sp;

    private bool flag = true; 
    private BoxCollider portalCollider;
    private CapsuleCollider cofreCollider1;
    private BoxCollider cofreCollider2;
    public GameObject cofrePrefab;

    void Start()
    {
        GameObject portal = GameObject.FindGameObjectWithTag("Portal");
        if (portal != null)
        {
            portalCollider = portal.GetComponent<BoxCollider>();
        }

        GameObject cofre = GameObject.FindGameObjectWithTag("Cofre");
        if (cofre != null)
        {
            cofreCollider1 = cofre.GetComponent<CapsuleCollider>();
            cofreCollider2 = cofre.GetComponent<BoxCollider>();
        }

        sp = GameObject.FindGameObjectsWithTag("Spawners");
        for(int i = 0; i < sp.Length; i++)
        {
            sp[i].SetActive(false);
        }
    }

    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("MeleeEnemy").Length <= 0 && wave != wState.max)
        {
            for(int i = 0; i < sp.Length; i++){
                sp[i].SetActive(true);
            }
            wave++;
            timeout = 5;
            
        }
        timeout -= Time.deltaTime;
        if (wave == wState.max && GameObject.FindGameObjectsWithTag("MeleeEnemy").Length <= 0 && timeout <= 0 && flag) 
        {
            activarColliders();
            flag = false;
        }
    }

    private void activarColliders()
    {
        portalCollider.isTrigger = true;
        cofreCollider1.isTrigger = true;
        cofreCollider2.isTrigger = true;
    }
}
