using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointCharacter : MonoBehaviour
{
    public Transform target;
    public CharacterController controller;
    public float speed = 1.0f;
    // Start is called before the first frame update
    private Vector3 velocity;
  
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 relativePos = target.position - transform.position;
        if(gameObject.tag == "coche"){
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up * Time.deltaTime);
            transform.rotation = rotation;
            if (relativePos.x <= 0)
                transform.Translate(transform.right * speed * Time.deltaTime);
            else 
                transform.Translate(-transform.right * speed * Time.deltaTime);
        }

        else if(gameObject.tag == "Floor"){
             if (relativePos.x >= 0)
                transform.Translate(transform.right * speed * Time.deltaTime);
            else 
                transform.Translate(-transform.right * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "WayPoint"){
            Debug.Log("Colision con waypoint");
            target = other.gameObject.GetComponent<WayPoint>().nextWayPoint;
            Debug.Log(target);
        }
    }

}
