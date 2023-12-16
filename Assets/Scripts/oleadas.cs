using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oleadas : MonoBehaviour
{
    public enum wState {siguiente, max};
    public wState wave = wState.siguiente;
    
    public GameObject[] sp;

    private bool flag = true; 
    private BoxCollider portalCollider;
    public GameObject cofrePrefab;

    void Start()
    {
        GameObject portal = GameObject.FindGameObjectWithTag("Portal");
        if (portal != null)
        {
            portalCollider = portal.GetComponent<BoxCollider>();
        }

        sp = GameObject.FindGameObjectsWithTag("Spawners");
        for(int i = 0; i < sp.Length; i++)
        {
            sp[i].SetActive(false);
        }
    }

    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("MeleeEnemy").Length <= 0)
        {
            sp[(int) wave].SetActive(true);
            wave++;
        }
        if (wave == wState.max && flag) 
        {
            generarCofre();
            flag = false;
            Debug.Log("Estado en max");
        }
    }

    private void generarCofre()
    {
        portalCollider.isTrigger = true;
        GameObject cofre = Instantiate(cofrePrefab);
        cofre.transform.position = new Vector3(-270, 0.5f, 50);
        flag = false;
    }
}
