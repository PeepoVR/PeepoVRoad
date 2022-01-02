using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public AudioSource audioSource;

    void Start () {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider collision){

        if (collision.gameObject.tag == "Player"){
            audioSource.Play();
            ContadorMonedas.contadorMonedas++;
            Destroy(gameObject);

        }
    }
}
