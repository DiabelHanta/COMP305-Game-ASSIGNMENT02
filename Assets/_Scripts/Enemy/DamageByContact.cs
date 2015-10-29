/*
	Rewritten code using "Space Shooter" tutorial and "Mail Pilot" demonstration in class as references
*/
using UnityEngine;
using System.Collections;

public class DamageByContact : MonoBehaviour 
{
	//PUBLIC INSTANCE VARIABLES
	public int enemyDamage = 10;

	//PRIVATE INSTANCE VARIABLES
	private ScoreManager _scoreManager; //object of type: "ScoreManager"
	//NOTE: references
	private Animator _anim;
	private GameObject _player;
	private PlayerHealth _playerHealth;

	void Awake()
	{
		//component references
		_player = GameObject.FindGameObjectWithTag ("Player");
		_playerHealth = _player.GetComponent <PlayerHealth> ();//script reference
		_anim = GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start ()
	{
		//Referencing to object with tag: "ScoreManager"
		GameObject scoreManagerObject = GameObject.FindWithTag ("ScoreManager"); 

		//conditional - debugging purpose (to see if script is being read
		if (scoreManagerObject != null) 
		{
			_scoreManager = scoreManagerObject.GetComponent<ScoreManager>(); 
		}
		
		if (_scoreManager == null) 
		{
			Debug.Log("Cannot find 'ScoreManager' script"); //insurance policy. hope this never gets called
		}
	}

	void Update()
	{
		if(_playerHealth.currentHealth <= 0)
		{
			_anim.SetInteger ("AnimState", 3);
		}
	}


	void OnTriggerEnter2D(Collider2D other) //other is an instance of Collider
	{
		//if hitting player
		if (other.tag == "Player") 
		{
//			if(_playerHealth.currentHealth > 0)
			_playerHealth.TakeDamage (enemyDamage);

		}

		//note: doesn't matter what the order is b/w these two.
		//			Destroy (other.gameObject);  //Moved from bottom to (if statement: other.tag)
		//			Destroy (gameObject); //Destroys all of the child objects w/i the parent
	}
}
