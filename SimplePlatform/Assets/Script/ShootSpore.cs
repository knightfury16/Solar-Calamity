using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpore : MonoBehaviour {

	public GameObject TheSpore;
	public Transform ShootPoint;
	public float shootTime;
	public int chanceOfShoot;

	float nextShootTime;
	Animator CannonShootAnim;



	// Use this for initialization
	void Start () {
		CannonShootAnim = GetComponentInChildren<Animator> ();
		nextShootTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag=="Player" && nextShootTime<Time.time)
		{
			nextShootTime = Time.time + shootTime;
			if(Random.Range (0,10)>=chanceOfShoot)
			{
				Instantiate (TheSpore,ShootPoint.position,Quaternion.identity);
				CannonShootAnim.SetTrigger ("cannonShoot");
			}
		}
	}
}
