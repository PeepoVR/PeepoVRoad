using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public OVRGrabbable grab;   
    float timer;
    public int contador;

    // Start is called before the first frame update
    void Start()
    {
            timer = 0;
            contador = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(grab.isGrabbed && gameObject.CompareTag("Coin")){
            timer += Time.deltaTime;
            if (timer > 3.0f)
             {
                Destroy(gameObject);
                timer = 0;
                contador++;
             }
        } 
    }

}
