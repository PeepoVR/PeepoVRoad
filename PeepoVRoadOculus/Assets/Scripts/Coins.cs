using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public OVRGrabbable grab;   
    private AudioSource audioSource;
    public float rotSpeed = 0.5f;

    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void Update() {
        transform.Rotate(0, 360 * this.rotSpeed * Time.deltaTime, 0);

        if(grab.isGrabbed && gameObject.CompareTag("moneda")){
            audioSource.Play();
            ContadorMonedas.contadorMonedas++;
            this.rotSpeed = 0;
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject, 2);
        } 
    }
}
