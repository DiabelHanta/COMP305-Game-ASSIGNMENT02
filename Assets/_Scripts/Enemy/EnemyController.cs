using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
	// PUBLIC INSTANCE VARIABLES
	public float speed = 100f;
	public Transform sightStart; //starting point for line cast
	public Transform sightEnd; //ending point for line cast

	// PUBLIC INSTANCE VARIABLES
	private Rigidbody2D _rb2d;
	private Transform _transform;
	private Animator _anim;

	//
	private bool _isGrounded = false;
	private bool _isGroundAhead = true; //line cast: warns enemy for alert (ie. fall)

	// Use this for initialization
	void Start () 
	{
		this._rb2d = gameObject.GetComponent<Rigidbody2D>();
		this._transform = gameObject.GetComponent<Transform> ();
		this._anim = gameObject.GetComponent<Animator> ();
	}
	
	// physics update
	void FixedUpdate () 
	{
		//is enemy grounded?
		if(this._isGrounded)
		{
			this._anim.SetInteger("AnimState", 1); //setting "AnimState" to refer in the "Animator" window (in unity)
			this._rb2d.velocity = new Vector2(this._transform.localScale.x, 0) * this.speed;

			//setting the actual "linecast"
			this._isGroundAhead = Physics2D.Linecast(this.sightStart.position, this.sightEnd.position, 1 << LayerMask.NameToLayer("Platform")); //NOTE: changed "Solid" to Platform
			Debug.DrawLine(this.sightStart.position, this.sightEnd.position);

			//nested if - flipping the sprite
			if(this._isGroundAhead == false)
			{
				this._flip();
			}
		}
		else
		{
			this._anim.SetInteger("AnimState", 0);
		}
	}

	//COLLISION METHODS
	void OnCollisionStay2D(Collision2D other)
	{
		//while the enemy is on an object with tag: "Platform" then continue
		if(other.gameObject.CompareTag("Platform"))
		{
			this._isGrounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Platform"))
		{
			this._isGrounded = false;
		}
	}

	//PRIVATE METHODS
	//flip method...
	private void _flip()
	{
		if(this._transform.localScale.x == 1)
		{
			this._transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		else
		{
			this._transform.localScale = new Vector3(1f, 1f, 1f);
		}
	}
}