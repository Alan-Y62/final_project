using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    MeshRenderer emit;

    public void HoverEmit(){
        emit = GetComponent<MeshRenderer>();
        emit.material.EnableKeyword("_EMISSION");
    }

    public void ExitEmit(){
        emit = GetComponent<MeshRenderer>();
        emit.material.DisableKeyword("_EMISSION");
    }
}
