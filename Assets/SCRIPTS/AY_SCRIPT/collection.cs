using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collection : MonoBehaviour
{
    public AudioSource collectSound;
    public GameObject wall;
    private int count = 3;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.tag == "Player")
        {
            GameObject.Find("Basketball_Court").GetComponent<scoreSystem>().enabled = false;
            collectSound.Play();
            goalstuff.collectibles++;
            count--;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(count == 0)
        {
            wall.SetActive(false);
        }
    }
}
