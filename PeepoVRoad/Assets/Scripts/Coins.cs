using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private AudioSource audioSource;
    public float rotSpeed = 0.5f;

    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void Update() {
        transform.Rotate(0, 360 * this.rotSpeed * Time.deltaTime, 0);
    }
    
    void OnTriggerEnter(Collider collision){

        if (collision.gameObject.tag == "Player"){
            audioSource.Play();
            ContadorMonedas.contadorMonedas++;
            
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject, 2);

        }
    }
}
