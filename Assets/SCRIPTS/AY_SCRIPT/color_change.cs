using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Hold code from https://www.youtube.com/watch?v=wWSYT-Yrr9E&list=WL&index=9&t=36s

public class color_change : MonoBehaviour
{
    public GameObject ball;
    public GameObject player;
    private Vector3 ballPos = new Vector3(240f,162.2f, -338.7f);


    public void Hold()
    {
        ball.transform.SetParent(player.transform.Find("Main Camera").transform);
        ball.transform.localPosition = new Vector3(0f, -2f, 4f);
    }

    public void throwB()
    {
        ball.GetComponent<Rigidbody>().useGravity = true;
        ball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.up * 10.0f, ForceMode.Impulse);
        ball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 30.0f, ForceMode.Impulse);
        ball.GetComponent<Transform>().SetParent(null);
    }

    private void OnCollisionEnter(Collision target)
    {
        if (target.transform.tag == "Reset")
        {
            ball.transform.position = ballPos;
            ball.GetComponent<Rigidbody>().Sleep();
            ball.GetComponent<Rigidbody>().useGravity = false;
        }

        if(target.transform.tag == "Scored")
        {
            scoreSystem.score++;
            ball.transform.position = ballPos;
            ball.GetComponent<Rigidbody>().Sleep();
            ball.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
