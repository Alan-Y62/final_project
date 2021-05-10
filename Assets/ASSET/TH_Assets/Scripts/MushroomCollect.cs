using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomCollect : MonoBehaviour{
    public AudioSource collectAudio;
    public AudioClip eatingSound;

    public void PointerClick(){
        collectAudio.GetComponent<AudioSource>().clip = eatingSound;
        collectAudio.Play();
        ScoreSystem.score += 1;
        Destroy(gameObject);
    }
}
