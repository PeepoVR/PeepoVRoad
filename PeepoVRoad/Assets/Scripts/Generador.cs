using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject objetoGenerado;
    public Transform position;
    public int range;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("spawn", 2f);
    }


    void spawn(){
        Instantiate(objetoGenerado, position.position, position.rotation);
        int repeatRate = Random.Range(2,range);
        Invoke("spawn", repeatRate);
       // Debug.Log(repeatRate);
    }
}
