using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour{
    public GameObject player;
    public string levelname;

    void OnTriggerEnter(Collider col){
        if(col.gameObject == player){
            Debug.Log("Start EndScene");
            SceneManager.LoadScene(levelname);
        }
    }
}
