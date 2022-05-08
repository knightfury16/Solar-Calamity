using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour {

	public AudioClip playerGrunt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			PlayerHealth PlayerFell = other.GetComponent<PlayerHealth> ();

			AudioSource.PlayClipAtPoint (playerGrunt,other.gameObject.transform.position);

			PlayerFell.makeDead ();



		} 

		else if(other.tag == "Spore"){
			Destroy (other.gameObject);
		}
		else
		{
			EnemyHealth kill = other.gameObject.GetComponent<EnemyHealth> ();
			kill.makedead ();
		}
			
	}
}
