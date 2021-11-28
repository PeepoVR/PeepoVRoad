using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().SetSource("stream", GetComponent<AudioSource>());
        FindObjectOfType<AudioManager>().Play("stream");
    }

}
