using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grab : MonoBehaviour
{
    public GameObject stick;
    public GameObject hand;
    public float pwr;
    bool inhands = false;
    private Vector3 size;
    private Vector3 handsize;
    private pick pickable;
    private float handx;
    private float handy;
    private float handz;
    private Vector3 reference;
    Collider stickcollider;
    Rigidbody stickRB;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        reference = hand.transform.localPosition;
        handx = hand.transform.localRotation.x;
        handy = hand.transform.localRotation.y;
        handz = hand.transform.localRotation.z;
        stickcollider = stick.GetComponent<BoxCollider>();
        stickRB = stick.GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
        size = stick.transform.localScale;
        handsize = new Vector3(1f, 0.3f, 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if (!inhands)
            {
                stickRB.isKinematic = true;
                stickcollider.isTrigger = true;
                
                stickRB.velocity = Vector3.zero;
                stickRB.useGravity = false;
                stick.transform.SetParent(hand.transform);
                stick.transform.localScale = handsize;
                stick.transform.localPosition = reference;
                //stick.transform.eulerAngles = new Vector3(0f + handx, 0f + handy, 0f+ handz);
                stick.transform.localRotation = Quaternion.Euler(handx, handy, handz);
                inhands = true;
            }
            else if (inhands)
            {
                stickcollider.isTrigger = false;
                stickRB.useGravity = true;
                stickRB.isKinematic = false;
                this.GetComponent<grab>().enabled = false;
                stick.transform.SetParent(null);
                stick.transform.localScale = size;
                stickRB.velocity = cam.transform.rotation * Vector3.forward * pwr;
                
                inhands = false; 
            }
        }
    }  
}
