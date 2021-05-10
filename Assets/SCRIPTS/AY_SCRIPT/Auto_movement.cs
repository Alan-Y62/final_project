using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//should change Auto_movement to the name of your script
public class Auto_movement : MonoBehaviour
{
    public float speed_; //movement speed

    public Transform vrCamera; //Used to control the transform methods of the Camera
    public float upperBoundsH = 30.0f; //Angle border, can play around with this further to adjust it to your scene
    public float lowerBoundsH = 10.0f;
    public bool moveForward; //boolean to determine whether to move forward or not
    private Vector3 ResetyPosety = new Vector3(-103f, 160f, -285f);
    public AudioSource steps;

    private CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>(); //don't know what this is really for but I assume it enables gyroscopic controls on devices
        speed_ = 40; //Movement speed, 10 is decent speed, 20 is like moving on a bike
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
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed_);
        }

        if (steps.isPlaying == false)
        {
            steps.volume = Random.Range(0.1f, 0.2f); //varies the volume
            steps.pitch = Random.Range(0.8f, 1.1f); //varies the pitch
            steps.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Trash"))
        {
            gameObject.transform.position = ResetyPosety;
        }
    }
}
