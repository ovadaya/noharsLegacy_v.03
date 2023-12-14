using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class hitboxe : MonoBehaviour
{
    public GameObject barravida;
    public float dmg;

    private float itime;
    public Vector3 knockback;
   
    public DatosJugador dato;
    void Start(){
        
        dato = barravida.GetComponent<DatosJugador>();
        
    }

    private void Update(){
        

    }
    private void OnTriggerEnter(Collider other) {
        print(other.tag);
         if(other.tag == "enemy"){
            print(other.tag);
            dato.recibirDano(dmg);
            transform.position = transform.position + knockback;
         }
    }
    
}

