using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	//COLLISION METHODS
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject); //destroys the item game object
		}
	}
}
