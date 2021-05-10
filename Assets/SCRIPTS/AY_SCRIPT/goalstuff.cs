using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class goalstuff : MonoBehaviour
{
    public GameObject goalDisplay;
    public static int collectibles;

    private void Update()
    {
        if(collectibles <3)
        {
            goalDisplay.GetComponent<Text>().text = "Collect the 3 golden items to continue (" + collectibles + "/3)";
        }
        else
        {
            goalDisplay.GetComponent<Text>().text = "You have collected them all, go to the yellow door to proceed!";
        }
        
    }
}
