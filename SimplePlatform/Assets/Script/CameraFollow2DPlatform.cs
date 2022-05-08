using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2DPlatform : MonoBehaviour {

	public Transform target;
	public float Smoothing;

	Vector3 offset;

	float lowY;


	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;

		lowY = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(target != null){
			Vector3 targetCameraPos = target.position + offset;

			transform.position = Vector3.Lerp (transform.position, targetCameraPos, Smoothing * Time.deltaTime);

			if (transform.position.y < lowY)
				transform.position =new Vector3 (transform.position.x, lowY, transform.position.z);
		}
	}
}
