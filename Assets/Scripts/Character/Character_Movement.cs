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
    public float sensitivityCamera = 100f;
    public bool isInAir;
    public bool jump = true;
    private float rot = 0f;
    Vector3 movement = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        controller = GetComponent<CharacterController>();
       // runningSound = GetComponent<AudioSource>().clip;
        controllerBody = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Camera movement
        float xRot = Input.GetAxis("Mouse X") * sensitivityCamera * Time.deltaTime;
        float yRot = Input.GetAxis("Mouse Y") * sensitivityCamera * Time.deltaTime;
        rot -= yRot;
        rot = Mathf.Clamp(rot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rot, 0f, 0f);
        controllerBody.Rotate(Vector3.up * xRot);
        //controllerBody.Rotate(Vector3.left * xRot);

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
            movement = new Vector3(0, 0, 1);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                movement *= runningSpeed;
            }
        }
        //spleen spin
        //Debug.Log(movement);
        Debug.Log(xRot + ", " + yRot);
        

        controller.Move(movement);
    }
    void FixedUpdate()
    {

    }
}
