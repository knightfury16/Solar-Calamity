using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHit : MonoBehaviour {

	public float WeaponDamage;

	projectileControl myPc;


	// Can access other script like this too.
	public GameObject explosion;


	// Use this for initialization


	void Awake () {
		myPc = GetComponentInParent<projectileControl> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	// Trigger is on,on the collider. When another collider comes in immediate contact then it is activated.

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable"))
		{
			myPc.removeForce ();
			Instantiate (explosion,transform.position,transform.rotation);


			Destroy (gameObject);
			if(other.tag=="Enemy")
			{
				EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth> ();

				hurtEnemy.addDamage (WeaponDamage);
			}
		}
	}

	// Trigger is on,on the collider. When another collider remains in contact then it is activated.

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer ("Shootable"))
		{
			myPc.removeForce ();
			Instantiate (explosion,transform.position,transform.rotation);
			Destroy (gameObject);
			if(other.tag=="Enemy")
			{
				EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth> ();

				hurtEnemy.addDamage (WeaponDamage);
			}
		}
	}
}
