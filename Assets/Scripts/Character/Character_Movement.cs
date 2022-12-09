using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{
    public CharacterController controller;
    //public Animator anim; //None yet
    //public AudioClip runningSound; //no
    public Transform controllerBody;
    public float MaxRunningSpeed = 12f;
    public float runningSpeed = 2f;
    public float gravity = 10f;
    public float sensitivity = 1f;
    public bool isInAir;
    public bool jump = true;
    private Vector3 rot = new Vector3(255,255,255);
    Vector3 movement = new Vector3(0, 0, 0);
    
    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Confined;
        controller = GetComponent<CharacterController>();
       // runningSound = GetComponent<AudioSource>().clip;
        controllerBody = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        //Camera movement
        rot = Input.mousePosition;
        rot = new Vector3(Input.mousePosition.y % 360, Input.mousePosition.x % 360, 0);
        transform.eulerAngles = rot;
        //Broken movement lol fix it soon. 
        if (Input.GetKey(KeyCode.W))
        {
            movement = new Vector3(0, 0, 1);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                movement *= runningSpeed;
            }
        }
        if (Input.GetKey(KeyCode.S)) 
        {
            movement = new Vector3(0, 0, -1);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                movement *= runningSpeed;
            }
        }
        //spleen spin
        //Debug.Log(movement);

        

        controller.Move(movement);
    }
    void FixedUpdate()
    {

    }
}
