using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDes : MonoBehaviour
{
    public GameObject player;

    public void TestDescription(){
        DesSystem.description = "Testing the warp information on canvas. Not sure how far the text can go. Hope it works out when I have more words in the description. Now go find some shrooms...";
        player.transform.position = new Vector3(180f, 2f, 133f);
        StartCoroutine(WaitTime());
    }

    public IEnumerator WaitTime(){
        yield return new WaitForSeconds(10f);
        DesSystem.description = "";
    }
}
