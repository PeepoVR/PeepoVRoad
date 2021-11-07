using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {
	public CharacterController controller;
	public float speed = 8f;
	public float gravity = -9.81f;
	public float jumpHeight = 0.5f;
	
	private bool playerOnTheFloor = true;
	Vector3 velocity;
	
	// Start is called before the first frame update
	void Start() {}
	
	// Update is called once per frame
	void Update() {
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		
		Vector3 move = transform.right * x + transform.forward * z;
		this.controller.Move(move * this.speed * Time.deltaTime);
		
		if (this.playerOnTheFloor && Input.GetButtonDown("Jump")) {
			this.velocity.y = Mathf.Sqrt(this.jumpHeight * -2f * this.gravity);
			playerOnTheFloor = false;
		}
		
		this.velocity.y += this.gravity * Time.deltaTime;
		this.controller.Move(this.velocity * Time.deltaTime);
	}
	
	public void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.CompareTag("Floor")) {
			this.playerOnTheFloor = true;
			this.velocity.y = 0;
		}
	}
}