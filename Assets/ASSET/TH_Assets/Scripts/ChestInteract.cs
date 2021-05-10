using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteract : MonoBehaviour{
    public GameObject chestCap;
    public AnimationClip open;
    public AnimationClip close;
    public AudioSource chestAudio;
    
    public void ChestOpen(){
        if(chestCap.GetComponent<Animation>().clip == open && ScoreSystem.score == 5){
            chestAudio.Play();
            chestCap.GetComponent<Animation>().Play();
            chestCap.GetComponent<Animation>().clip = close;
        }
    }

    public void ChestClose(){
        if(chestCap.GetComponent<Animation>().clip == close){
            chestAudio.Play();
            chestCap.GetComponent<Animation>().Play();
            chestCap.GetComponent<Animation>().clip = open;
        }
    }
}
