using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public void RestartLVL()
    {
        SceneManager.LoadScene("Scene1");
       Time.timeScale = 1f;
    }
}
