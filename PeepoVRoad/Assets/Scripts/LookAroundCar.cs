using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAroundCar : MonoBehaviour {
	
	public float lookSpeed = 1000f;
	
	float xRotation = 0f;
	float yRotation = 0f;
	
	void Start() {
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	void Update() {
		float mult = this.lookSpeed * Time.deltaTime;
		float rotationY = Input.GetAxis("Mouse X") * mult;
		float rotationX = Input.GetAxis("Mouse Y") * mult;
		
		this.xRotation -= rotationX;
		this.xRotation = Mathf.Clamp(this.xRotation, -90f, 90f);
		this.yRotation += rotationY;
		
		transform.localRotation = Quaternion.Euler(this.xRotation, this.yRotation, 0f);
	}
}