using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToEndScreen : MonoBehaviour
{
     [SerializeField] private string newLevel = "EndScreen";
	 private bool collidingWithCuby;
	 private bool collidingWithSquaresome;
	/*
	void OnTriggerEnter2D(Collider2D other){
	    if(other.CompareTag("Cuby") && other.CompareTag("Squaresome")){
			SceneManager.LoadScene(newLevel);
		}	
	}	 */
	
	void OnTriggerEnter2D(Collider2D col)
{
    if (col.CompareTag("Cuby"))
    {
        collidingWithCuby = true ;
    }
    else if (col.CompareTag("Squaresome"))
    {
        collidingWithSquaresome = true ;
    }

    if( collidingWithCuby && collidingWithSquaresome )
    {
       SceneManager.LoadScene(newLevel);
    }
}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.CompareTag("Cuby"))
		{
			collidingWithCuby = false;
		}
		else if (col.CompareTag("Squaresome"))
		{
			collidingWithSquaresome = false;
		}
	}
}
