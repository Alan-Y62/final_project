using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCollider : MonoBehaviour{
    public GameObject player;
    public AudioSource collideSound;
    private bool waitCoroutine = false;
    
    void OnTriggerEnter(Collider col){
        collideSound.Play();
        if(ScoreSystem.score == 5 && !waitCoroutine){
            waitCoroutine = true;
            DesSystem.description = "Locate the Key";
            StartCoroutine(WaitTime());
        }else if(!waitCoroutine){
            waitCoroutine = true;
            DesSystem.description = "The barrier is up. Find more Gems";
            StartCoroutine(WaitTime());
        }
    }

    public IEnumerator WaitTime(){
        yield return new WaitForSeconds(3f);
        DesSystem.description = "";
        waitCoroutine = false;
    }
}
