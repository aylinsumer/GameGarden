using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 12f;
    public CharacterController myController;
    public Transform myCameraHead;

    public float mouseSensibility = 700f;
    private float cameraVerticalRotation;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensibility * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensibility * Time.deltaTime;
       
        cameraVerticalRotation -= mouseY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation,-90f,90f);
       
       
        transform.Rotate(Vector3.up * mouseX);
        myCameraHead.localRotation = Quaternion.Euler(cameraVerticalRotation,0f,0f);
    }
    void PlayerMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movement = x*transform.right + z*transform.forward;
        //movement = movement*speed*Time.deltaTime;
        myController.Move(movement*speed*Time.deltaTime);

    }
}
