using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosCountDestroy : MonoBehaviour {

	public GameObject Enenmy;
	Animator Door;
	public GameObject WinStar;
	public Transform StarPoint;
	public int bossValue;

	int counter=0;

	// Use this for initialization
	void Start () {


		Door = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (counter == bossValue) {
			Door.SetBool ("DoorOn", true);

		}
	

	}

	public void Bosscounter()
	{
		counter++;
		Debug.Log (counter);
	}

//	void OnTriggerEnter2D(Collider2D other)
//	{
//		if(other.tag=="Player")
//		{
//			Instantiate (WinStar,StarPoint.position,Quaternion.identity);
//		}
//	}
}
