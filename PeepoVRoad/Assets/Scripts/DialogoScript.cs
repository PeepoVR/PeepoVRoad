using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogoScript : MonoBehaviour
{
    public GameObject gazeInputObject;
    public GameObject panel;
    public TextMeshPro texto;

    private int monedasNecesarias = 5;
    private void OnTriggerEnter(Collider colideObj)
    {
        if (colideObj.gameObject.CompareTag("Player"))
        {
            panel.SetActive(true);
            if(ContadorMonedas.contadorMonedas == monedasNecesarias){
                texto.SetText("Veo que tienes las peepoCoins, entra al coche chaval.");
                gazeInputObject.GetComponent<GazeInput>().enabled=true;
            }else{
                texto.SetText("Te faltan "+ (monedasNecesarias-ContadorMonedas.contadorMonedas) +" peepoCoins, estas cuajado niño, sin mi dinero no trabajo.");
                gazeInputObject.GetComponent<GazeInput>().enabled=false;
            }

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
