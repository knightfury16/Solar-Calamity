﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_win : MonoBehaviour {

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
			PlayerHealth win = other.gameObject.GetComponent<PlayerHealth> ();

			win.GameWin ();
		}
	}
}
