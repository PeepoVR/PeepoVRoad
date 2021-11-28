using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pajarito : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Bird());
    }

    private IEnumerator Bird()
    {
        while (true)
        {
            int i = Random.Range(1, 6);
            FindObjectOfType<AudioManager>().SetSource("bird_" + i, GetComponent<AudioSource>());
        
            FindObjectOfType<AudioManager>().Play("bird_" + i);

            float seconds = Random.Range(2.0f, 5.0f);
            yield return new WaitForSeconds(seconds);
        }

    }
}
