using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect : MonoBehaviour
{
    public GameObject display;
    public GameObject goal;
    public GameObject fdisplay;
    public Vector3 resetP;

    private void Start()
    {
        resetP = transform.position;   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("collider"))
        {
            GameObject.Find("Basketball_Court").GetComponent<scoreSystem>().enabled = true;
            goal.SetActive(false);
            display.SetActive(true);
        }
        if(other.CompareTag("fdisplay"))
        {
            goal.SetActive(false);
            fdisplay.SetActive(true);
        }
        if(other.CompareTag("Trash"))
        {
            transform.position = resetP;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("collider"))
        {
            display.SetActive(false);
            goal.SetActive(true);
        }
        if(other.CompareTag("fdisplay"))
        {
            fdisplay.SetActive(false);
        }
        if (other.CompareTag("waypoint"))
        {
            goal.SetActive(true);
        }
    }
}
