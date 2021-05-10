using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
	public GameObject Dumbell1;
	public GameObject VRcardboard;

	bool inHands = false;
	Vector3 dumbell1position;

    // Start is called before the first frame update
    void Start()
    {
	dumbell1position = Dumbell1.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
	if (Input.GetButtonDown("Fire1"))
	{
		if (!inHands){
			Dumbell1.transform.SetParent(VRcardboard.transform);
			Dumbell1.transform.localPosition = new Vector3(-.016f, 0f, .038f);
			inHands = true;
		} else if (inHands)
		{
			this.GetComponent<PlayerGrab>().enabled = false;
			Dumbell1.transform.SetParent(null);
			Dumbell1.transform.localPosition = dumbell1position;
			keepscore.Score += 100;
			inHands = false;
		}
	}

        
    }
}
