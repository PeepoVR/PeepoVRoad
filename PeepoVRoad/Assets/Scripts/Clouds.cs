using UnityEngine;
using System.Collections;

public class Clouds : MonoBehaviour {

    public int cloudsSpeed = 5;
    public int cloudsMoveRange = 150;
    
    private Vector3 initialPosition;

    void Start() {
       this.initialPosition  = this.transform.position;
    }

    // Update is called once per frame
    void Update() {
        //Translates the cloud to the right at the speed that is selected
        transform.Translate(this.cloudsSpeed * Time.deltaTime, 0, 0);
        
        if (this.cloudsMoveRange - this.transform.position.x < 0.5)
            this.transform.position = new Vector3(-this.cloudsMoveRange, this.initialPosition.y, this.initialPosition.z);
    }
}