using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SitDown : MonoBehaviour
{
    public GameObject player;
    public Text des;
    public Vector3 vector;

    public void sit(){
        des.text = "Sitting down to enjoy the scenery and hear the birds";
        //vector = this.transform.position;
        vector = new Vector3(this.transform.position.x, this.transform.position.y+3, this.transform.position.z-2);
        player.transform.position = vector;
        player.transform.rotation = this.transform.rotation;
    }
}
