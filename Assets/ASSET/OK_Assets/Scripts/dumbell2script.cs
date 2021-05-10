using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dumbell2script : MonoBehaviour
{
    	public GameObject Dumbell2;
	public GameObject VRcardboard;

	bool inHands = false;
	Vector3 dumbell2position;

    // Start is called before the first frame update
    void Start()
    {
	dumbell2position = Dumbell2.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
	if (Input.GetButtonDown("Fire1"))
	{
		if (!inHands){
			Dumbell2.transform.SetParent(VRcardboard.transform);
			Dumbell2.transform.localPosition = new Vector3(.012f, 0.001f, .037f);
			inHands = true;
		} else if (inHands)
		{
			this.GetComponent<dumbell2script>().enabled = false;
			Dumbell2.transform.SetParent(null);
			Dumbell2.transform.localPosition = dumbell2position;
			keepscore.Score += 100;
			inHands = false;
		}
	}

        
    }
}
