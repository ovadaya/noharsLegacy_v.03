using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(25f);
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

}
