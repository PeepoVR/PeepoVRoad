using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ardilla : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Sound());
    }

    private IEnumerator Sound()
    {
        while (true)
        {
            int i = Random.Range(1, 3);

            FindObjectOfType<AudioManager>().SetSource("squirrel_" + i, GetComponent<AudioSource>());
            FindObjectOfType<AudioManager>().Play("squirrel_" + i);

            float seconds = Random.Range(16.0f, 25.0f);
            yield return new WaitForSeconds(seconds);
        }

    }
}
