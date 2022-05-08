using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementControler : MonoBehaviour {

	public float ChargingSpeed;


	Animator enemyAnimator;

	//facing
	public GameObject enemyGraphic;
	public SpriteRenderer enemySprite;
	bool canFlip=true;
//	bool facingRight=false;
	float flipTime=3f;
	float nextFlipChance=0f;

	//attacking

	public float chargeTime;
	float startChargeTime;
	bool charging;
	Rigidbody2D enemyRB;





	// Use this for initialization
	void Start () {
		enemyAnimator = GetComponentInChildren<Animator> ();
		enemyRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		//flipping here
		if(Time.time>nextFlipChance)
		{
			if (Random.Range (1, 10) >= 5)
			{
				if (canFlip) {

					if (enemySprite.flipX == true)
						enemySprite.flipX = false;
					else
						enemySprite.flipX = true;
				}
			}

			nextFlipChance = Time.time + flipTime;
		}
	}



	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag=="Player")
		{
			SpriteRenderer playerSprite = other.gameObject.GetComponent<SpriteRenderer> ();

			if(enemyGraphic.transform.position.x < other.gameObject.transform.position.x && enemySprite.flipX==false)
			{
				enemySprite.flipX = true;
			}
			else if(enemyGraphic.transform.position.x > other.gameObject.transform.position.x && enemySprite.flipX==true)
			{
				enemySprite.flipX = false;
			}
				
			canFlip = false;

			charging = true;
			startChargeTime = Time.time + chargeTime;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag=="Player")
		{
			if(enemySprite != null && startChargeTime<Time.time)
			{
				if (enemySprite.flipX == false)
					enemyRB.AddForce (new Vector2 (-1f, 0f) * ChargingSpeed);
				else
					enemyRB.AddForce (new Vector2 (1f, 0f) * ChargingSpeed);

				enemyAnimator.SetBool ("isCharging",charging);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag=="Player")
		{
			canFlip = true;
			charging = false;
			enemyRB.velocity = new Vector2 (0f, 0f);
			enemyAnimator.SetBool ("isCharging",charging);
		}
	}



}
