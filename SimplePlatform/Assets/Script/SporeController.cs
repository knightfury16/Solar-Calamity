using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeController : MonoBehaviour {

	public float sporeSpeedHigh;
	public float sporeSpeedLow;
	public float sporeAngle;
	public float sporeTorqueAngle;


	Rigidbody2D myRB;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
		myRB.AddForce (new Vector2(Random.Range (-sporeAngle,sporeAngle),Random.Range (sporeSpeedHigh,sporeSpeedLow)),ForceMode2D.Impulse);
		myRB.AddTorque (Random.Range (-sporeTorqueAngle,sporeTorqueAngle));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
