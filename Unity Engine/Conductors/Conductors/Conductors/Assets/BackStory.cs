using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackStory : MonoBehaviour
{
    public void BackStoryPage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 8);
    }
}
