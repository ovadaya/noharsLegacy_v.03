using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SplashController : MonoBehaviour
{
    void Update()
    {
        // make that if presses any key or click the mouse, it loads the next scene
        if (Input.anyKeyDown)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        if (Time.time > 5)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
