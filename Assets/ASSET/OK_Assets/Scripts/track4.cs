using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class track4 : MonoBehaviour
{
	public GameObject Trackcube4;
	public GameObject VRcardboard;

	bool inHands = false;
	Vector3 trackcube4position;


    // Start is called before the first frame update
    void Start()
    {
        
	trackcube4position = Trackcube4.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

if (Input.GetButtonDown("Fire1"))
	{
		if (!inHands){
			Trackcube4.transform.SetParent(VRcardboard.transform);
			Trackcube4.transform.localPosition = new Vector3(.012f, 0.001f, .037f);
			inHands = true;
			keepscore.Score += 100;
		
		}
	}
         else if (inHands)
		{
			this.GetComponent<track1>().enabled = false;
			Trackcube4.transform.SetParent(null);
			Trackcube4.transform.localPosition = trackcube4position;
			Destroy(Trackcube4);
			inHands = false;
		}




    }
	


}
