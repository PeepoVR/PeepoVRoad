using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoScript : MonoBehaviour
{

    public GameObject panel;

    public float tiempoEntrada;

    private void OnTriggerEnter(Collider colideObj)
    {
        if (colideObj.gameObject.CompareTag("Player"))
        {
          
            panel.SetActive(true);
            StartCoroutine(ExampleCoroutine());

        }
    }

    private void OnTriggerExit(Collider colideObj)
    {
        if (colideObj.gameObject.CompareTag("Player"))
        {
   
            panel.SetActive(false);
            StartCoroutine(ExampleCoroutine());
        }
    }

    IEnumerator ExampleCoroutine()
    {
        

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

   
    }



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
