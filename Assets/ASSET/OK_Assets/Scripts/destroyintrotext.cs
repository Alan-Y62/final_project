using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyintrotext : MonoBehaviour
{
    public float interval;
    void Start()
    {
        Destroy (gameObject, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
