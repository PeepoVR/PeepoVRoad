using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coche : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null) {
            audioManager.SetSource("carSound", GetComponent<AudioSource>());
            audioManager.Play("carSound");
        }
    }
}
