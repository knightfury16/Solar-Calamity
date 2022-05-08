using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {

	public float healthAmount;

	public AudioClip heartPickupAudio;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag=="Player")
		{

			AudioSource.PlayClipAtPoint (heartPickupAudio,transform.position);

			PlayerHealth HealthGain = other.gameObject.GetComponent<PlayerHealth> ();

			HealthGain.addHealth (healthAmount);

			Destroy (gameObject);

		}
	}
}
