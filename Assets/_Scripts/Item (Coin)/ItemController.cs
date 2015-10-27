using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour 
{
	public int scoreValue = 10;

	//COLLISION METHODS
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject); //destroys the item game object
			ScoreManager.score += scoreValue; //adds score to scoreText
		}
	}
}
