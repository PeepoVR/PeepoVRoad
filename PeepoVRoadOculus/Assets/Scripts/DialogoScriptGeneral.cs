using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogoScriptGeneral : MonoBehaviour
{
    public GameObject panel;

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
        yield return new WaitForSeconds(0);

   
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
