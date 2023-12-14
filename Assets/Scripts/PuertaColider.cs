using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaColider : MonoBehaviour
{
    private BoxCollider miBoxCollider;

    void Start()
    {
        miBoxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (HayEnemigosVivos())
        {
           Debug.Log("Has ganado el nivel");
            miBoxCollider.isTrigger = true;
        }
        else
        {
            miBoxCollider.isTrigger = false;
            GameObject[] enemigos = GameObject.FindGameObjectsWithTag("MeleeEnemy");
           // Debug.Log(enemigos);
        }
    }

    private bool HayEnemigosVivos()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("MeleeEnemy");
        return enemigos.Length == 0;
    }
}
