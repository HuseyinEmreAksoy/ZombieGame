using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Strating : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1;
        Debug.Log("Clicked!!");
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        Debug.Log("Play the gamee!!");
    }
}
