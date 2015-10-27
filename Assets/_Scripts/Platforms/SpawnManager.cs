using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour 
{
	//PUBLIC INSTANCE VARIABLES
		//NOTE: variables are used to spawn platforms
	public int maxPlatforms = 20;
	public GameObject platform; //reference to platform prefab

	//spawns PLATFORMS to either right/left (depending on floating value)
	public float horizontalMin = 5f;
	public float horizontalMax = 15f;

	//spawns PLATFORMS to either up/down (depending on floating value)
		//NOTE: corresponding with horizontal direction
	public float verticalMin = -5f;
	public float verticalMax = 5f;

	//PRIVATE INSTANCE VARIABLES
	//original position of platform (using GameObject Transform reference)
	private Vector2 _originPosition;

	//START METHOD
	void Start()
	{
		//first position of this object's transform position
		_originPosition = transform.position;
		Spawn (); //method call
	}

	//PRIVATE METHOD - spawns platform
	void Spawn()
	{
		//for loop - cloning platforms from original platform's position
		for (int count = 0; count < maxPlatforms; count++) 
		{
			// creates new object in new position from first position (originPosition)
			Vector3 randomPosition = _originPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
			
			//NOTE: Instantiate clones of the object and creates the clone
			Instantiate(platform, randomPosition, Quaternion.identity); //NOTE: "identity" means no rotation
			
			//NOTE:  creates clones by offsetting from original object until maxPlatforms is reached
			_originPosition = randomPosition;
		}
	}
}
