using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToLevel2 : MonoBehaviour
{
     [SerializeField] private string newLevel = "Level2";
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
// Don't forget to set the variables to false when your object exits the triggers!
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
