using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    public void HowTo()
    {
        //Access the How to Play page from the main menu
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
        }
        //Access How to Play Page from BackStory
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
        
    }
}
