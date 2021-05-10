using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreSystem : MonoBehaviour
{
    public GameObject scoreDisplay;
    public GameObject goal;
    public GameObject particles;
    public GameObject reward;
    public static int score;

    private void Update()
    {
        if(score < 3)
        {
            scoreDisplay.GetComponent<Text>().text = "SCORE: " + score + "/3";
        }
        else
        {
            particles.SetActive(true);
            scoreDisplay.SetActive(false);
            goal.SetActive(true);
            reward.SetActive(true);
        }
    }
}
