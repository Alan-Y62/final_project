using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Movement_Script : MonoBehaviour
{
    public float speed_; //movement speed

    public Transform vrCamera; //Used to control the transform methods of the Camera
    public float toggleAngle = 30.0f; //Angle border, can play around with this further to adjust it to your scene
    public bool moveForward; //boolean to determine whether to move forward or not

    private CharacterController cc;
    private int count;
    public Text countText;

    public GameObject door;
    public AudioSource footstep;

    public Text description;

    void Start()
    {
        cc = GetComponent<CharacterController>(); //don't know what this is really for but I assume it enables gyroscopic controls on devices
        speed_ = 10; //Movement speed, 10 is decent speed, 20 is like moving on a bike
	count=0;
	CountText();

        description.text = "Find all 4 objects to advance to the next scene!";
    }

    void OnTriggerEnter(Collider other)
    {
	if (other.gameObject.tag == "item")
	{
	    other.gameObject.SetActive(false);
	    count=count+1;
	    CountText();
	}
    }

    void CountText()
    { 
	    countText.text = "Count: " + count.ToString();
        if(count == 4)
        {
            openDoor();
        }
    }

    void openDoor()
    {
        door.SetActive(true);
    }

    void Update()
    {
        //if camera tilt downard is betwen 10 and 30 degrees, move forward
        if (vrCamera.eulerAngles.x < toggleAngle && vrCamera.eulerAngles.x > 10)
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
            if (footstep.isPlaying == false)
            {
                footstep.volume = Random.Range(0.1f, 0.2f); //varies the volume
                footstep.pitch = Random.Range(0.8f, 1.1f); //varies the pitch
                footstep.Play();
            }
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed_);
        }
    }
}
