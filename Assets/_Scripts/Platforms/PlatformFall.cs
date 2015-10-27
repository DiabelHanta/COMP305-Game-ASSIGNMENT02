using UnityEngine;
using System.Collections;

public class PlatformFall : MonoBehaviour 
{
	//PUBLIC INSTANCE VARIABLES
	public float fallDelay = 1f;

	//PRIVATE INSTANCE VARIABLES
	private Rigidbody2D _rb2d;

	// FIRST FRAME
	void Awake () 
	{
		_rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// COLLISION METHODS
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			//NOTE: calls Fall() method and then sets timer (ie. float = 1f)
			Invoke("Fall", fallDelay);
		}
	}

	//METHOD - delay for fall
	void Fall()
	{
		_rb2d.isKinematic = false; //unchecks kinimatic - objects falls to oblivion
	}
}
