using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esfera : MonoBehaviour
{
    // Start is called before the first frame update
 private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        
        }
    }
}

