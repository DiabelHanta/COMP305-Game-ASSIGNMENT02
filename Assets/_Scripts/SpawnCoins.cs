using UnityEngine;
using System.Collections;

public class SpawnCoins : MonoBehaviour 
{
	//PUBLIC INSTANCE VARIABLES
	public Transform[] coinSpawn; //array
	public GameObject coin;

	// Use this for initialization
	void Start () 
	{
		Spawn ();
	}
	
	//
	void Spawn()
	{
		//
		for(int count = 0; count < coinSpawn.Length; count++)
		{
			int coinFlip = Random.Range(0, 2); //randomizing coin placement
			//coinditional - 
			if(coinFlip > 0)
			{
				Instantiate(coin, coinSpawn[count].position, Quaternion.identity);
			}
		}
	}
}
