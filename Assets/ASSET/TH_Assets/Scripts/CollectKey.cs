using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectKey : MonoBehaviour{
    public GameObject originalObject;
    public GameObject handObject;
    public GameObject forceField;

    public void PointerClick(){
        forceField.SetActive(false);
        Destroy(originalObject);
        handObject.SetActive(true);
    }
}
