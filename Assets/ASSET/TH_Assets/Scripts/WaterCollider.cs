using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollider : MonoBehaviour{
    public AudioSource walkingAudio;
    public AudioClip waterClip;
    public AudioClip groundClip;
    public GameObject player;

    void OnTriggerEnter(Collider col){
        if(col.gameObject == player){
            Debug.Log("Found Water");
            walkingAudio.clip = waterClip;
        }
    }

    void OnTriggerExit(Collider col){
        walkingAudio.clip = groundClip;
    }
}
