using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    private int cantidade = 1;
    [SerializeField] private GameObject enemytype;

    void Update()
    {
        if (cantidade > 0) {
            spawnE();
            cantidade--;
        }
    }

    void spawnE()
    {
        GameObject enemyClone = Instantiate(enemytype, transform.position, Quaternion.identity);
    }
}
