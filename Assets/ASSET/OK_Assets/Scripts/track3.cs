using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track3 : MonoBehaviour
{
	public GameObject Trackcube3;
	public GameObject VRcardboard;

	bool inHands = false;
	Vector3 trackcube3position;


    // Start is called before the first frame update
    void Start()
    {
        
	trackcube3position = Trackcube3.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

if (Input.GetButtonDown("Fire1"))
	{
		if (!inHands){
			Trackcube3.transform.SetParent(VRcardboard.transform);
			Trackcube3.transform.localPosition = new Vector3(.012f, 0.001f, .037f);
			inHands = true;
			keepscore.Score += 100;
		
		}
	}
         else if (inHands)
		{
			this.GetComponent<track1>().enabled = false;
			Trackcube3.transform.SetParent(null);
			Trackcube3.transform.localPosition = trackcube3position;
			Destroy(Trackcube3);
			inHands = false;
		}




    }
	


}
