using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CocheFin : MonoBehaviour
{
     private void OnTriggerEnter(Collider colideObj)
    {
        if (ContadorMonedas.contadorMonedas >= 5)
            SceneManager.LoadScene("Loading");
    }
}
