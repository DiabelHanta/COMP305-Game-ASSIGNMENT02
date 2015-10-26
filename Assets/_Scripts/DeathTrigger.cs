using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	//NOTE: on trigger reloads the level/game
	void OnTriggerEnter2D(Collider2D other)
	{
		//
		if (other.gameObject.CompareTag ("Player")) 
		{
			//reopens the scene
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
