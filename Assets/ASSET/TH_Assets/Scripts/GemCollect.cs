using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollect : MonoBehaviour{
    public AudioSource collectAudio;
    public AudioClip gemSound;
    public GameObject spawnShroom1, spawnShroom2, spawnShroom3, spawnShroom4,spawnShroom5;
    public AudioSource growAudio;

    public void PointerClick(){
        collectAudio.GetComponent<AudioSource>().clip = gemSound;
        collectAudio.Play();
        ScoreSystem.score += 1;
        Destroy(gameObject);

        if(ScoreSystem.score == 5){
            growAudio.Play();
            spawnShroom1.GetComponent<Animation>().Play();
            spawnShroom2.GetComponent<Animation>().Play();
            spawnShroom3.GetComponent<Animation>().Play();
            spawnShroom4.GetComponent<Animation>().Play();
            spawnShroom5.GetComponent<Animation>().Play();
        }
    }
}
