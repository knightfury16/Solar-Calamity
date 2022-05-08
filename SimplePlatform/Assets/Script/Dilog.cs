using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dilog : MonoBehaviour {

	public TextMeshProUGUI textDisplay;
	[TextArea(3,10)]
	public string[] sentences;
	private int index;
	public float typingSpeed;
	public Animator animator;

	public GameObject continueButton;
	public GameObject skipButton;

	void Start(){
		
		StartCoroutine (Type ());
	
	}

	void Update(){

		if (textDisplay.text == sentences [index]) {
			continueButton.SetActive (true);
		}
	
	}

	IEnumerator Type()
	{
		foreach (char letter in sentences[index].ToCharArray ()) {

			textDisplay.text += letter;

			yield return new WaitForSeconds (typingSpeed);
		
		}
			
	}

	public void NextSentence()
	{
		continueButton.SetActive (false);

		if (index < sentences.Length - 1) {
			index++;
			textDisplay.text = "";
			StartCoroutine (Type ());

		} else {
			textDisplay.text = "";
			continueButton.SetActive (false);
			Debug.Log ("Finish");
			animator.SetBool ("isOpen",false);
		
		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" && index==0) {
			animator.SetBool ("isOpen",true);
		}
	}
		
	void OnTriggerExit2D(Collider2D other){

		if(other.tag == "Player"){
			animator.SetBool ("isOpen", false);
		}
	}

	public void SkipDilog()
	{
		animator.SetBool ("isOpen",false);
		index++;
	}

}
