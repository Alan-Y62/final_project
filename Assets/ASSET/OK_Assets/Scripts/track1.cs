using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track1 : MonoBehaviour
{
	public GameObject Trackcube1;
	public GameObject VRcardboard;

	bool inHands = false;
	Vector3 trackcube1position;


    // Start is called before the first frame update
    void Start()
    {
        
	trackcube1position = Trackcube1.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

if (Input.GetButtonDown("Fire1"))
	{
		if (!inHands){
			Trackcube1.transform.SetParent(VRcardboard.transform);
			Trackcube1.transform.localPosition = new Vector3(.012f, 0.001f, .037f);
			inHands = true;
			keepscore.Score += 100;
		
		}
	}
         else if (inHands)
		{
			this.GetComponent<track1>().enabled = false;
			Trackcube1.transform.SetParent(null);
			Trackcube1.transform.localPosition = trackcube1position;
			Destroy(Trackcube1);
			inHands = false;
		}




    }
	


}
