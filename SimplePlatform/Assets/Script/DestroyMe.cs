using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour {

	public float aliveTym;

	// Use this for initialization
	void Awake () {

		Destroy (gameObject,aliveTym);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
