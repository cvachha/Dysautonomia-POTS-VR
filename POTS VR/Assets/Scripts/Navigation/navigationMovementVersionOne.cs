using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navigationMovementVersionOne : MonoBehaviour {
	public float speed = 5.0f;
	public float speedH = 2.0f;
	public float speedV = 2.0f;

	private float yaw = 0.0f;
	private float pitch = 0.0f;
	float inputX;
	float inputZ;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update(){
		inputX = Input.GetAxis ("Horizontal");
		inputZ = Input.GetAxis ("Vertical");

		if (inputX != 0) {
			transform.Rotate(new Vector3(0.0f,inputX*Time.deltaTime,0.0f));
		}

		if (inputZ != 0) {
			transform.position += transform.forward * inputZ * Time.deltaTime;
		}

}
}
