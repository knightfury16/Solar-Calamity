using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {

	public float restartTime;
	bool restartNow=false;
	float resetTime;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(restartNow && resetTime<=Time.time)
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

	public void restartTheGame()
	{
		restartNow = true;
		resetTime = Time.time + restartTime;
	}
}
