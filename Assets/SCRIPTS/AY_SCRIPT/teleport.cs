using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{

    public GameObject player;
    public GameObject sob;
    private Vector3 telePos = new Vector3(92f, 10f, -332f);

    public void teleporter()
    {
        player.transform.position = telePos;
        StartCoroutine("Timer");
        sob.SetActive(true);
        StopCoroutine("Timer");
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2f);
    }
}
