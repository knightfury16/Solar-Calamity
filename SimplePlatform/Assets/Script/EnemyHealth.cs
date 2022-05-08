using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public float maxEnemyHealth;

	public GameObject EnemyDeathFX;
	public GameObject HearthForHealth;


	public bool drop;


	//Boss counter
	public bool Boss;
	public GameObject door;

	public Slider EnemySlider2;

	public AudioClip deathKnell;

	public float tym;

	float currentHealth=0f;


	// Use this for initialization
	void Start () {

		currentHealth = maxEnemyHealth;
		EnemySlider2.maxValue = currentHealth;
		EnemySlider2.value = currentHealth;
	}

	public void addDamage(float damage)
	{
		EnemySlider2.gameObject.SetActive (true);
		currentHealth -= damage;
		EnemySlider2.value = currentHealth;

		if (currentHealth <= 0)
			makedead ();
	}



	public void makedead()
	{
		
		Destroy (gameObject);
		Destroy (gameObject.transform.parent.gameObject, tym);
		AudioSource.PlayClipAtPoint (deathKnell, transform.position);
		Instantiate (EnemyDeathFX, transform.position, transform.rotation);
		if (drop) {
			if (Random.Range (1, 10) >= 5) {
				Instantiate (HearthForHealth, transform.position, transform.rotation);
			}
		}

		if(Boss)
		{
			BoosCountDestroy bosskilled = door.GetComponent<BoosCountDestroy> ();

			bosskilled.Bosscounter ();
		}

	

	}
}
