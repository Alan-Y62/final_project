using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//should change Auto_movement to the name of your script
public class walk : MonoBehaviour
{
    public float speed_; //movement speed
    public TextMeshProUGUI counttext;
    public GameObject blocked;
    public GameObject unblocked;
    public GameObject the_stick;
    public AudioSource playsound;
    public AudioSource walkingAudio;
    public Transform vrCamera; //Used to control the transform methods of the Camera
    public float toggleAngle = 30.0f; //Angle border, can play around with this further to adjust it to your scene
    public bool moveForward; //boolean to determine whether to move forward or not
    [SerializeField]
    private GameObject trash_gate;
    private CharacterController cc;
    private int count;

    void Start()
    {
        cc = GetComponent<CharacterController>(); //don't know what this is really for but I assume it enables gyroscopic controls on devices
        count = 0;
        unblocked.SetActive(false);

        setcount();
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
        if (moveForward)
        {
            if (walkingAudio.isPlaying == false)
            {
                walkingAudio.volume = Random.Range(0.1f, 0.2f); //varies the volume
                walkingAudio.pitch = Random.Range(0.8f, 1.1f); //varies the pitch
                walkingAudio.Play();
            }
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed_);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Trash"))
        {
            other.gameObject.SetActive(false);
            playsound.Play();
            count = count + 1;

            setcount();
        }

        if(other.gameObject.CompareTag("Gate"))
        {
            if (count >= 20)
            {
                other.gameObject.SetActive(false);
                unblocked.SetActive(false);
            }
        }

        if (other.gameObject.CompareTag("stickcheck"))
        {
            other.gameObject.SetActive(false);
            the_stick.SetActive(false);
        }
    }

    void setcount()
    {
        counttext.text = "Trash Collected: " + count.ToString() + "/20";
        if ( count >= 20)
        {
            trash_gate.SetActive(false);
            blocked.SetActive(false);
            unblocked.SetActive(true);
        }
    }

}
