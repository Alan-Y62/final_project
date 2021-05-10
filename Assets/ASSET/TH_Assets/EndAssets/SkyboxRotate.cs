using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotate : MonoBehaviour{
    public float RotationSpeed = 1.4f;

    void Update(){
        RenderSettings.skybox.SetFloat("_Rotation",Time.time*RotationSpeed);
    }
}
