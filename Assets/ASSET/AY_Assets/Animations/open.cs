using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open : MonoBehaviour
{
    private Animator anim1;
    private Animator anim2;
    public GameObject left;
    public GameObject right;
    // Start is called before the first frame update
    void Start()
    {
        anim1 = left.GetComponent<Animator>();
        anim2 = right.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            anim1.SetBool("opened", true);
            anim2.SetBool("opened", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim1.SetBool("opened", false);
            anim2.SetBool("opened", false);
        }
    }
}
