using UnityEngine;
using System.Collections;

//VELOCITY UTILITY CLASS
public class VelocityRange
{
	//PUBLIC INSTANCE VARIABLES
	public float vMin, vMax;

	//CONSTRUCTOR
	public VelocityRange(float vMin, float vMax)
	{
		this.vMin = vMin;
		this.vMax = vMax;
	}
}

public class PlayerController : MonoBehaviour 
{
	//PUBLIC INSTANCE VARIABLES
	public float speed = 50f;
	public float jump = 500f;
	public VelocityRange velocityRange = new VelocityRange(300f, 1000f); //restricting min and max for velocity range

	//PRIVATE INSTANCE VARIABLES
	private AudioSource[] _audioSources; //array of audio sources
	private AudioSource _coinSound; //pickup coin sound
	private AudioSource _hitSound;
	private Rigidbody2D _rb2d;
	private Transform _transform;
	private Animator _anim;

	//
	private float _movingValue = 0f;
	private bool _isFacingRight = true;
	private bool _isGrounded = true;

	// Use this for initialization
	void Start () 
	{
		//Object references
		this._rb2d = gameObject.GetComponent<Rigidbody2D> ();
		this._transform = gameObject.GetComponent<Transform> ();
		this._anim = gameObject.GetComponent<Animator> ();

		this._audioSources = gameObject.GetComponents<AudioSource>();
		//audio references
		this._coinSound = this._audioSources [0];
		this._hitSound = this._audioSources [1];
	}

	// Physics update
	void FixedUpdate () 
	{
		//"forced" positions
		float forceX = 0f;
		float forceY = 0f;

		//Absolute values of rigidbody's velocity
		float absVelocityX = Mathf.Abs (this._rb2d.velocity.x);
		float absVelocityY = Mathf.Abs (this._rb2d.velocity.y);

		//Horizontal movement for player
		this._movingValue = Input.GetAxis ("Horizontal");

		//CONDITIONAL - give player "movement"
		if (_movingValue != 0) 
		{
			//checks if player is grounded
			if (this._isGrounded) 
			{
				this._anim.SetInteger ("AnimState", 1);

				//neseted CONDITIONAL - moves player right
				if (this._movingValue > 0) 
				{
					//moves right
					if (absVelocityX < this.velocityRange.vMax) 
					{
						forceX = this.speed;
						this._isFacingRight = true;
						this._flip ();
					}
				} 

				else if (this._movingValue < 0) 
				{
					//moves left
					if (absVelocityX < this.velocityRange.vMax) {
						forceX = -this.speed;
						this._isFacingRight = false;
						this._flip ();
					}
				}
			}
		}
		//
		else
		{
			//set idle animation here
			this._anim.SetInteger("AnimState", 0);
		}
	
		//checks if player is jumping (using ARROW-UP/'W')
		//			//conditional for input button for "jump" (NOTE: FROM BASIC TUTORIAL)
		//			if (Input.GetButtonDown ("Jump") && _grounded) 
		//			{
		//				// boolean used to ensure when player is jumping
		//				jump = true;
	
		//checks if player is jumping
		if(Input.GetButtonDown ("Jump"))
		{
			//checks if player is grounded
			if(this._isGrounded)
			{
				this._anim.SetInteger("AnimState", 2);
				if(absVelocityY < this.velocityRange.vMax)
				{
					forceY = this.jump;
//					this._jumpSound.Play();
					this._isGrounded = false;
				}
			}
		}
		//adds force for player to move him
		this._rb2d.AddForce(new Vector2(forceX, forceY));

		//INSERT (DEATH ANIMATION: this._anim.SetInteger("AnimState" 3)
	}

	//INSERT AUDIO FILE!
	//COLLISION METHODS
	void OnCollisionEnter2D(Collision2D other)
	{
		//player hits coin then play "_elfSound"
		if(other.gameObject.CompareTag("Coin"))
		{
			this._coinSound.Play ();
		}
	}

	//INSERT/CHANGE: 
	void OnCollisionStay2D(Collision2D other)
	{
		//player hits/touches platform then "isGrounded" is set to true
		//NOTE: allows player to hit "jump"
		if(other.gameObject.CompareTag("Platform"))
		{
			this._isGrounded = true;
		}
	}

	//PRIVATE METHODS
	//flipping sprite's direction
	private void _flip()
	{
		if(this._isFacingRight)
		{
			//changes scale of the sprite
			this._transform.localScale = new Vector3(1f, 1f, 1f); //resets to normal scale
		}
		else
		{
			this._transform.localScale = new Vector3(-1f, 1f, 1f); //changes the scale to opposite
		}
	}
}