using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charge : MonoBehaviour
{
    public float rspeed = 40f;
    private float randMod;

    private void Start()
    {
        randMod = Random.Range(1, 10);
        rspeed += randMod;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = new Vector3(rspeed, 0f, 0f);
        GetComponent<Rigidbody>().AddForce(force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("destroy"))
        {
            Destroy(gameObject);
        }
    }
}
