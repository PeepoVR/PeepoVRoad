using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour {
	
	public float lookSpeed = 1000f;
	
	public Transform playerBody;
	
	float xRotation = 0f;
	
	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update() {
		float mult = this.lookSpeed * Time.deltaTime;
		float rotationY = Input.GetAxis("Mouse X") * mult;
		float rotationX = Input.GetAxis("Mouse Y") * mult;
		
		this.xRotation -= rotationX;
		this.xRotation = Mathf.Clamp(this.xRotation, -90f, 90f);
		
		transform.localRotation = Quaternion.Euler(this.xRotation, 0f, 0f);
		this.playerBody.Rotate(Vector3.up * rotationY);
	}
}