using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTP : MonoBehaviour{
    public GameObject player;
    public GameObject portalOne;
    public GameObject portalTwo;
    private GameObject other;
    public bool teleported = false;
    public AudioSource teleportAudio;

    void OnTriggerEnter(Collider col){
        if(col.gameObject == player && !teleported){
            teleportAudio.Play();
            other = (this.name == portalOne.name) ? portalTwo:portalOne;

            other.GetComponent<PortalTP>().teleported = true;  

            CharacterController cc = player.GetComponent<CharacterController>();
            cc.enabled = false;
            player.transform.position = other.transform.position;
            cc.enabled = true;

            Debug.Log(col.name + " teleports from: "+this.transform.position + " to "+ other.transform.position);  
        }
    }

    void OnTriggerExit(Collider col){
        if(col.gameObject == player){
            teleported = false;
        }
    }
}
