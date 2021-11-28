using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirObjetos : MonoBehaviour
{
     void OnCollisionEnter(Collision collision){
       
        if (collision.gameObject.tag == "coche"){
           Destroy(collision.gameObject);
           
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Floor"){
           Destroy(other.gameObject);
        }
    }
}
