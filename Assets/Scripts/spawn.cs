using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeField] private int cantidade;
    [SerializeField] private GameObject enemytype;

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
    }

    void Update()
    {
        if (cantidade > 0) {
            spawnE();
            cantidade--;
        }
        if(cantidade == 0)
        {
            if (flag) 
            {
                generarCofre();
                flag = false;
            } 
        }
    }

    void spawnE()
    {
        GameObject enemyClone = Instantiate(enemytype, transform.position, Quaternion.identity);
    }

    private void generarCofre()
    {
        portalCollider.isTrigger = true;
        GameObject cofre = Instantiate(cofrePrefab);
        cofre.transform.position = new Vector3(-270, 0.5f, 50);
        flag = false;
        Debug.Log("Cofre generado");
    }
}
