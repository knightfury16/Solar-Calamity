using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour {

	public float maxSpeed;


	// Normal moving(left and right) variable.
	Rigidbody2D myRb;
	Animator myAnim;
	SpriteRenderer mySprite;
	bool facingRight;



	//jumping variables

	bool Grounded=false;
	float GroundCheckRadius=0.02f;
	public LayerMask GroundLayer;
	public Transform GroundCheck;
	public float jumpHeight;
	//Jump audio
	public AudioClip JumpAudio;


	//Shooting variables

	public Transform GunTipRight;
	public Transform GunTipLeft;
	public GameObject bullet;
	float FireRate=0.5f;
	float nextFire=0f;


	// Use this for initialization

	void Start () {
		myRb = GetComponent<Rigidbody2D> ();
		myAnim = GetComponent<Animator> ();
		mySprite = GetComponent<SpriteRenderer> ();


		facingRight = true;
	}
	
	// Update is called once per frame

	void Update()
	{
		float yInput = Input.GetAxisRaw ("Vertical");
		// Input.GetAxis ("Jump")>0

		if(Grounded && yInput>0)
		{
			
			AudioSource.PlayClipAtPoint (JumpAudio,transform.position);
			Grounded = false;
			myAnim.SetBool ("isGrounded",Grounded);
			myRb.AddForce (new Vector2(0,jumpHeight));

		}


	//player shooting

		if (Input.GetAxis ("Jump") > 0)
			fireRocket ();
	}





	void FixedUpdate () {


		//check if we are grounded,if not then falling

		Grounded = Physics2D.OverlapCircle (GroundCheck.position, GroundCheckRadius, GroundLayer);
		myAnim.SetBool ("isGrounded",Grounded);

		myAnim.SetFloat ("VerticalSpeed",myRb.velocity.y);


		// For moving left and right.

		float xInput = Input.GetAxis ("Horizontal");
		myAnim.SetFloat ("speed", Mathf.Abs (xInput));

		myRb.velocity = new Vector2(xInput*maxSpeed , myRb.velocity.y);

	//	myRb.velocity = Vector2.right * xInput * maxSpeed;


		if(xInput>0){
			mySprite.flipX = false;	
		}

		else if(xInput<0)
		{
			mySprite.flipX = true;
		}

	}

	void flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void fireRocket()
	{
		if(Time.time>nextFire)
		{
			nextFire = Time.time + FireRate;

			if(mySprite.flipX==false)
			{
				Instantiate (bullet, GunTipRight.position, GunTipRight.rotation);
			}
			else if(mySprite.flipX==true)
			{
				Instantiate (bullet, GunTipLeft.position, Quaternion.Euler (new Vector3 (0,0,180f)));
			}

		}
	}
}
