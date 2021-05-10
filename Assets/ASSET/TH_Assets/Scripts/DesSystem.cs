using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesSystem : MonoBehaviour{
    public GameObject desText;
    public static string description;


    void Update(){
        desText.GetComponent<Text>().text = description;
    }
}
