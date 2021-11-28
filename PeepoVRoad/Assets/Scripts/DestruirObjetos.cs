using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirObjetos : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "coche"){
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Floor"){
           Destroy(other.gameObject);
        }
    }
}
