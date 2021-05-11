using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fgrab : MonoBehaviour
{
    public GameObject d;
    public GameObject gold;

    public void Fgrab()
    {
        GetComponent<Rigidbody>().Sleep();
        GetComponent<Rigidbody>().useGravity = false;
        transform.SetParent(d.transform.Find("Main Camera").transform);
        transform.localPosition = new Vector3(0f, -2f, 4f);
    }

    public void Fdrop()
    {
        transform.SetParent(null);
        GetComponent<Rigidbody>().useGravity = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            gold.SetActive(true);
        }
    }
}
