using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyActive : MonoBehaviour{
    public AudioSource forceAudio;

    void Awake(){
        forceAudio.Play();
        DesSystem.description = "The barrier is down";
        StartCoroutine(WaitTime());
    }

    public IEnumerator WaitTime(){
        yield return new WaitForSeconds(5f);
        DesSystem.description = "";
    }
}
