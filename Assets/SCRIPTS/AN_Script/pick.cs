using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick : MonoBehaviour
{
    private Rigidbody rb;
    public Rigidbody Rb => rb;

    private void PU()
    {
        rb = GetComponent<Rigidbody>();
    }
}
