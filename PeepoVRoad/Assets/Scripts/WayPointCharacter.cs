using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointCharacter : MonoBehaviour
{
    public CharacterController controller;
    public Transform target;
    public float speed = 1.0f;
    // Start is called before the first frame update
     float gravity = -9.81f;
    private Vector3 velocity;
  
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up * Time.deltaTime);
        transform.rotation = rotation;

        controller.Move(transform.forward * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if (hit.gameObject.CompareTag("WayPoint"))
        {
            Debug.Log("Colision con waypoint");
            target = hit.gameObject.GetComponent<WayPoint>().nextWayPoint;
        }
    }
}
