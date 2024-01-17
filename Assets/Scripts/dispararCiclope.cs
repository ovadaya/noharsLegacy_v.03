using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dispararCiclope : MonoBehaviour
{
    [SerializeField] private float timer = 5;

    private float bullettime;

    public Transform player;

    public GameObject enemyBullet;

    public Transform spawnPoint;

    public float espeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        disparar();
    }

    void disparar(){
        bullettime -= Time.deltaTime;

        if(bullettime>0) return;

        bullettime = timer;

        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody rig = bulletObj.GetComponent<Rigidbody>();
        rig.AddForce(rig.transform.forward * espeed);
        Destroy(bulletObj, 5f);

    }

   
}
