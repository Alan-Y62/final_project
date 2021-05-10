using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track2 : MonoBehaviour
{
	public GameObject Trackcube2;
	public GameObject VRcardboard;

	bool inHands = false;
	Vector3 trackcube2position;


    // Start is called before the first frame update
    void Start()
    {
        
	trackcube2position = Trackcube2.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

if (Input.GetButtonDown("Fire1"))
	{
		if (!inHands){
			Trackcube2.transform.SetParent(VRcardboard.transform);
			Trackcube2.transform.localPosition = new Vector3(.012f, 0.001f, .037f);
			inHands = true;
			keepscore.Score += 100;
		
		}
	}
         else if (inHands)
		{
			this.GetComponent<track1>().enabled = false;
			Trackcube2.transform.SetParent(null);
			Trackcube2.transform.localPosition = trackcube2position;
			Destroy(Trackcube2);
			inHands = false;
		}




    }
	


}
