using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockGate : MonoBehaviour{
    public AudioSource rockBreakAudio;
    public GameObject originalObject;
    public GameObject fracturedObject;
    private bool clicked = false;
    private bool waitCoroutine = false;

    public void GateBreak(){
        if(ScoreSystem.score == 5 && !clicked){
            clicked = true;
            rockBreakAudio.Play();
            DesSystem.description = "Road is now clear";
            StartCoroutine(WaitTime());
        }else if(ScoreSystem.score != 5 && !clicked && !waitCoroutine){
            DesSystem.description = "Road is blocked. Find more Mushrooms.";
            waitCoroutine = true;
            StartCoroutine(WaitTime());
        }
    }

    public IEnumerator WaitTime(){
        yield return new WaitForSeconds(3f);  

        if(ScoreSystem.score == 5 && clicked == true){
            Destroy(originalObject);
            GameObject fracObject = Instantiate (fracturedObject) as GameObject;
            fracObject.GetComponent<ExplodeRock>().Explode();
            DesSystem.description = "";
            ScoreSystem.score = 0;
        }else{
            DesSystem.description = "";
            waitCoroutine = false;
        }
    }
}
