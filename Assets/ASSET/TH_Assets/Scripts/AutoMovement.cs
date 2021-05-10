using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//should change Auto_movement to the name of your script
public class AutoMovement : MonoBehaviour
{
    public float speed_; //movement speed

    public Transform vrCamera; //Used to control the transform methods of the Camera
    public float upperBoundsH = 30.0f; //Angle border, can play around with this further to adjust it to your scene
    public float lowerBoundsH = 10.0f;
    public bool moveForward; //boolean to determine whether to move forward or not
    public AudioSource walkingAudio;

    private CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>(); //don't know what this is really for but I assume it enables gyroscopic controls on devices
        //speed_ = 20; //Movement speed, 10 is decent speed, 20 is like moving on a bike
    }

    void Update()
    {
        //if camera tilt downard is betwen 10 and 30 degrees, move forward
        if (vrCamera.eulerAngles.x < upperBoundsH && vrCamera.eulerAngles.x > lowerBoundsH)
        {
            moveForward = true;
        }
        else
        {
            moveForward = false;
        }
        //Code that actually moves the player/Camera forward
        if(moveForward)
        {
            if(walkingAudio.isPlaying == false){
                walkingAudio.volume = Random.Range(0.1f,0.2f); 
                walkingAudio.pitch = Random.Range(0.8f,1.1f); 
                walkingAudio.Play();
            }
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed_);
        }
    }
}
