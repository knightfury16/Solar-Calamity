using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour {

	private GameMaster gm;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent <GameMaster> ();
		transform.position = gm.lastCheckPoint;
	}
	
	// Update is called once per frame
//	void Update () {
//		if (Input.GetKeyDown ("R")) {
//			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
//		}
//	}
}
