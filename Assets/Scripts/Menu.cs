using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Menu : MonoBehaviour
{
    public AudioSource clickVoice;
    
    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void PlayGame()
    {
        clickVoice.Play();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        clickVoice.Play();
        Application.Quit();
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }

    
}
