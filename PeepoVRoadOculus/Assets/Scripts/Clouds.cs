using UnityEngine;
using System.Collections;

public class Clouds : MonoBehaviour {

    Vector3 m;

    void Start() {
       // m  = new Vector3(-26, transform.position.y , transform.position.z);
    }

    // Update is called once per frame
    void Update() {
        //Translates the cloud to the right at the speed that is selected
        transform.Translate(5 * Time.deltaTime, 0, 0);
    }

     public void OnTriggerEnter (Collider hit) {
        
        if (hit.gameObject.CompareTag("Resistance"))
        {
            Debug.Log("Colision con waypoint");
            transform.position = new Vector3(95, transform.position.y , transform.position.z);
        }
    }
}