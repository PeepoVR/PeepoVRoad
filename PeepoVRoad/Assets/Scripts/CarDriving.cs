using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDriving : MonoBehaviour {
	public interface SpeedControls {
		
		public float Throttle {get;}
		public float Brake {get;}
		
		public void UpdateCurrentSpeedInput();
	}
	
	private class KeyboardControls : SpeedControls {
		public float Throttle {get;set;} = 0;
		public float Brake {get;set;} = 0;
		
		public void UpdateCurrentSpeedInput() {
			this.Throttle = Input.GetAxis("Throttle");
			this.Brake = Input.GetAxis("Brake");
		}
	}
	
	private class GanmePadControls : SpeedControls {
		public float Throttle {get;set;} = 0;
		public float Brake {get;set;} = 0;
		
		public void UpdateCurrentSpeedInput() {
			this.Throttle = (Input.GetAxis("GamePadThrottle") + 1) / 2;
			this.Brake = (Input.GetAxis("GamePadBrake") + 1) / 2;
		}
	}
	
	private class AcceletarionConfig {
		private float[] maxSpeeds;
		private float[] acelerations;
		
		public AcceletarionConfig(float[,] config) {
			this.maxSpeeds = new float[config.GetLength(0)];
			this.acelerations = new float[config.GetLength(0)];
			
			for (int i = 0; i < config.GetLength(0); i++) {
				this.maxSpeeds[i] = config[i, 0];
				this.acelerations[i] = config[i, 1];
			}
		}
		
		public float GetAcelerationForSpeed(float speed) {
			for (int i = 0; i < this.maxSpeeds.Length; i++) {
				if (this.maxSpeeds[i] > speed) {
					//Debug.Log(acelerations[i]);
					return acelerations[i];
				}
			}
			throw new InvalidOperationException();
		}
	}
	
	private AcceletarionConfig throttleAccels;
	private AcceletarionConfig brakeAccels;
	private AcceletarionConfig frictionAccelerations;
	
	public Transform frontShaft;
	public float maxTurnDegrees = 20;
	public float maxSpeed = 30;
	
	public Transform steeringWheel;
	public int maxSteeringWheetRot_visual = 80;
	
	private float shaftsDist;
	private SpeedControls speedControls;
	private float speed = 0;
	
	void Start() {
		bool connectedController = Input.GetJoystickNames().Length != 0 && Input.GetJoystickNames()[0].Length != 0;
		this.speedControls = connectedController ? (SpeedControls) new GanmePadControls() : (SpeedControls) new KeyboardControls();
		this.shaftsDist = Vector2.Distance(vector3to2D(this.frontShaft.position), vector3to2D(transform.position));
		
		this.throttleAccels = new AcceletarionConfig(new float[4, 2] {
			{this.maxSpeed / 6f, 5}, //1s
			{this.maxSpeed * (5f / 6f), 6.67f}, //3s
			{this.maxSpeed, 0.417f}, //12s
			{this.maxSpeed * 2, 0}
		});
		this.brakeAccels = new AcceletarionConfig(new float[3, 2] {
			{0, 0},
			{this.maxSpeed * 0.26f, -13},
			{this.maxSpeed * 2, -25}
		});
		this.frictionAccelerations = new AcceletarionConfig(new float[3, 2] {
			{0, 0},
			{this.maxSpeed / 3f, -3},
			{this.maxSpeed * 2, -6}
		});
	}
	
	void Update() {
		if (this.speed != 0) {
			float rotTime = this.shaftsDist / this.speed;
			transform.Rotate(new Vector3(0, (Time.deltaTime / rotTime) * this.maxTurnDegrees * Input.GetAxis("Horizontal"), 0));
			transform.Translate(new Vector3(0, 0, this.speed * Time.deltaTime));
		}
		
		this.speedControls.UpdateCurrentSpeedInput();
		float accelMultiplier = 1;
		AcceletarionConfig accelConfig;
		
		if (this.speedControls.Brake != 0) {
			accelConfig = this.brakeAccels;
			accelMultiplier = this.speedControls.Brake;
		}
		
		else if (this.speedControls.Throttle != 0) {
			accelConfig = this.throttleAccels;
			accelMultiplier = this.speedControls.Throttle;
			
			float targetSpeed = this.maxSpeed * accelMultiplier;
			if (this.speed > targetSpeed) {
				accelConfig = this.frictionAccelerations;
				accelMultiplier = 1;
			}
		}
		
		else
			accelConfig = this.frictionAccelerations;
		
		this.speed += accelConfig.GetAcelerationForSpeed(this.speed) * accelMultiplier * Time.deltaTime;
		if (this.speed < 0.0001)
			this.speed = 0;
		
		UpdateEfects();
	}
	
	private Vector2 vector3to2D(Vector3 vect) {
		return new Vector3(vect.x, vect.z);
	}
	
	void OnCollisionStay(Collision collision) {
		if (! collision.gameObject.CompareTag("Floor"))
			this.speed = Math.Min(this.speed, 10);
	}
	
	private void UpdateEfects() {
		if (this.steeringWheel != null) {
			Vector3 rot = this.steeringWheel.localEulerAngles;
			this.steeringWheel.localEulerAngles = new Vector3(rot.x, rot.y, Input.GetAxis("Horizontal") * this.maxSteeringWheetRot_visual);
		}
	}
}