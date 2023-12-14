using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeField] private int cantidade;

    [SerializeField] private GameObject enemytype;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cantidade > 0){
            spawnE();
            cantidade--;
        }
    }

     void spawnE(){
        
            
            GameObject enemyClone = Instantiate(enemytype, transform);
       

    }
}
