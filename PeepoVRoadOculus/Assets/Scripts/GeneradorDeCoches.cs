using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeCoches : MonoBehaviour
{
    public GameObject coche;
    public Transform position;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawn",  1, Random.Range(1,4));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawn(){
        coche = (GameObject)Instantiate(coche, position.position, position.rotation);

        //coche.GetComponent<WayPointCharacter>() = Random.Range(1,10);
        //coche.target = WayPoint2;
    }
}
