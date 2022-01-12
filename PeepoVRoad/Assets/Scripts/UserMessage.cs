using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMessage : MonoBehaviour {
	
	public float messageTime = 3;
	
	public Material bgMat;
	public MeshRenderer backgroundMeshRenderer;
	private MeshRenderer meshRenderer;
	
	private TextMesh textMesh;
	
	public void Start() {
		this.textMesh = GetComponent<TextMesh>();
		this.meshRenderer = GetComponent<MeshRenderer>();
		
		SetVisible(false);
	}
	
	public void ShowMessage(String text, Color bgColor, Action disappearCallback) {
		this.textMesh.text = text;
		this.bgMat.SetColor("_Color", bgColor);
		SetVisible(true);
		StartCoroutine(ShowMessageCoroutine(disappearCallback));
	}
	
	private IEnumerator ShowMessageCoroutine(Action callback) {
		yield return new WaitForSeconds(this.messageTime);
		callback();
	}
	
	private void SetVisible(bool visible) {
		this.backgroundMeshRenderer.enabled = visible;
		this.meshRenderer.enabled = visible;
	}
}