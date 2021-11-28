using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Choque : MonoBehaviour
{
    void OnTriggerEnter(Collider collision){
        if (collision.gameObject.tag == "coche")
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
