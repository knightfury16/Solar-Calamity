using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finaldoor : MonoBehaviour {

//	public GameObject Enenmy;
//	Animator Door;
	public GameObject WinStar;
	public Transform StarPoint;
//	public int bossValue;

	int counter=0;

	// Use this for initialization
	void Start () {



	}




		void OnTriggerEnter2D(Collider2D other)
		{
			if(other.tag=="Player")
			{
				Instantiate (WinStar,StarPoint.position,Quaternion.identity);
			}
		}
}
