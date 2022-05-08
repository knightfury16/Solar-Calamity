using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float MaxHealth;
	public GameObject deathFX;

	public RestartGame TheGameManager;


	//Audio manager

	public AudioClip playerHurt;

	AudioSource playerAS;

	public AudioClip PlayerDeathSound;

	Playermovement controlMovement;

	//HUD variable
	public Slider healthSlider;
	public Image damageScreen;
	public Text gameOverScreen;
	public Text gameWinScreen;
	public Button retryButton;

	bool damaged=false;
	Color damagedColor = new Color (0f, 0f, 0f, 0.5f);
	float smoothColor=5f;


	// Dilog box animator

	public Animator dilogBox;



	float currentHealth;

	// Use this for initialization
	void Start () {

		currentHealth = MaxHealth;
		controlMovement = GetComponent<Playermovement> ();

		//HUD initialization
		healthSlider.maxValue = MaxHealth;
		healthSlider.value = MaxHealth;

		//Audio initialization

		playerAS = GetComponent<AudioSource> ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(damaged)
		{
			damageScreen.color = damagedColor;
		}
		else 
		{
			damageScreen.color = Color.Lerp (damageScreen.color, Color.clear, smoothColor * Time.deltaTime);
		}

		damaged = false;


	}


	public void addDamage(float Damage)
	{
		if (Damage <= 0)
			return;

		currentHealth -= Damage;

		//Audio
		playerAS.clip = playerHurt;
		playerAS.Play ();

		healthSlider.value = currentHealth;
		damaged = true;

		if (currentHealth <= 0)
			makeDead ();
	}

	public void addHealth(float HealthAmount)
	{
		currentHealth += HealthAmount;
		if (currentHealth > MaxHealth)
			currentHealth = MaxHealth;

		healthSlider.value = currentHealth;
	}

	public void makeDead()
	{
		Instantiate (deathFX,transform.position,transform.rotation);
		Destroy (gameObject);
		AudioSource.PlayClipAtPoint (PlayerDeathSound,transform.position);
		damageScreen.color = damagedColor;

		Animator dead = gameOverScreen.GetComponent<Animator> ();

		dilogBox.SetBool ("isOpen",false);
		dead.SetTrigger ("GameOver");

		TheGameManager.restartTheGame ();
	}

	public void GameWin()
	{
		Destroy (gameObject);

		Animator dead = gameWinScreen.GetComponent<Animator> ();

		dead.SetTrigger ("GameOver");

//		retryButton.gameObject.SetActive (true);



	}

}
