using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().SetSource("carSound", GetComponent<AudioSource>());
        FindObjectOfType<AudioManager>().Play("carSound");
    }
}
