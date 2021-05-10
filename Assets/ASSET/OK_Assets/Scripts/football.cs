using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class football : MonoBehaviour
{
    	public GameObject Football1;
	public GameObject VRcardboard;

	bool inHands = false;
	Vector3 football1position;
	public float ballDistance = 2f;
	public float ballThrowingForce = 2f;

    // Start is called before the first frame update
    void Start()
    {
	football1position = Football1.transform.position;
	Football1.GetComponent<Rigidbody>().useGravity = false;
        
    }

    // Update is called once per frame
    void Update()
    {
	if (Input.GetButtonDown("Fire1"))
	{
		if (!inHands){
			Football1.transform.SetParent(VRcardboard.transform);
			Football1.transform.localPosition = new Vector3(.012f, 0.001f, .037f);
			inHands = true;
		} else if (inHands)
		{
			this.GetComponent<football>().enabled = false;
			Football1.transform.SetParent(null);
			Football1.GetComponent<Rigidbody>().useGravity = true;
			Football1.transform.localPosition = VRcardboard.transform.position + VRcardboard.transform.forward * ballDistance ;
			Football1.GetComponent<Rigidbody>().AddForce(VRcardboard.transform.forward * ballThrowingForce);
			keepscore.Score += 100;
			inHands = false;
		}
	}

        
    }
}
