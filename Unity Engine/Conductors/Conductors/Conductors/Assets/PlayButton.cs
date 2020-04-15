using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
   public void PlayGame(){

        //This wil take the user from the Introduction Page to the first level
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 6);
        }
        //This will take the user from the main menu to the introduction page
        else if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
        }
        //This will take the user from the How to Play page to the Introduction page
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        //This will take the user from the Introduction of Level 3 to Level 3
        else if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 6);
        }
        //This will take the suer from the Introduction of Level 4 to Level 4
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 6);
        }
   }
}
