using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peepo : MonoBehaviour {
	public AudioSource carHitAudioSource;
	
	private Animator anim;
	
	[Range(0, 1)]
	public float noExpression = 0;
	[Range(0, 1)]
	public float sad = 0;
	[Range(0, 1)]
	public float angry = 0;
	[Range(0, 1)]
	public float smoking = 0;
	[Range(0, 1)]
	public float stand = 0;
	[Range(0, 1)]
	public float sit = 0;
	[Range(0, 1)]
	public float gorrocoptero = 0;
	
	public float walkSpeed;
	public Transform[] targets;
	private IEnumerator<Transform> targetIter;
	private Vector3 targetPos;
	
	private Action updatePosFunc;
	
	public void Start() {
		this.anim = GetComponent<Animator>();
		this.anim.SetFloat("NoExpression", this.noExpression);
		this.anim.SetFloat("Sad", this.sad);
		this.anim.SetFloat("Angry", this.angry);
		this.anim.SetFloat("Smoking", this.smoking);
		this.anim.SetFloat("Stand", this.stand);
		this.anim.SetFloat("Sit", this.sit);
		this.anim.SetFloat("Gorrocoptero", this.gorrocoptero);
		
		this.anim.SetFloat("Walk", targets.Length == 0 ? 0 : 1);
		
		if (targets.Length == 0)
			this.updatePosFunc = () => {};
		
		else {
			this.anim.speed = this.walkSpeed * 1.5f;
			this.updatePosFunc = UpdatePosWalk;
			this.targetIter = ((IEnumerable<Transform>) this.targets).GetEnumerator();
			NextTarget();
		}
	}
	
	public void Update() {
		this.updatePosFunc();
	}
	
	private void UpdatePosWalk() {
		if (Vector3.Distance(transform.position, this.targetPos) < 0.1) {
			NextTarget();
			transform.rotation = Quaternion.LookRotation(this.targetPos - transform.position);
		}
		transform.position += (this.targetPos - transform.position).normalized * this.walkSpeed * Time.deltaTime;
	}
	
	private void NextTarget() {
		if (! this.targetIter.MoveNext()) {
			this.targetIter.Reset();
			this.targetIter.MoveNext();
		}
		this.targetPos = this.targetIter.Current.transform.position;
		this.targetPos.y = transform.position.y;
	}
	
	public void RunOver(float carSpeed, Vector3 carDirection) {
		this.updatePosFunc = () => {};
		GetComponent<BoxCollider>().enabled = false;
		
		bool leftHit = Vector3.Cross(carDirection, transform.forward).y < 0;
		transform.localRotation = Quaternion.LookRotation(-carDirection) * Quaternion.Euler(0, leftHit ? 90 : -90, 0);
		
		ClearAnims();
		this.anim.SetFloat("RunOver", 1);
		this.anim.SetFloat(leftHit ? "RunOverFlyLeft" : "RunOverFlyRight", 1);
		
		this.anim.speed = carSpeed * 0.7f;
		this.anim.Play("Base Layer.AnimsBlendTree", 0, 0);
		
		this.carHitAudioSource.Play();
		Destroy(this.gameObject, 4);
	}
	
	private void ClearAnims() {
		this.anim.SetFloat("Smoking", 0);
		this.anim.SetFloat("Stand", 0);
		this.anim.SetFloat("Walk", 0);
		this.anim.SetFloat("Sit", 0);
	}
}