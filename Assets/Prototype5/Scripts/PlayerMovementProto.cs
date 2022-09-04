using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementProto : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;
    public bool freeze;

    float yRotation;
    float xRotation;
    float lookSensitivity = 2f;
    float currentXRotation;
    float currentYRotation;
    float yRotationV;
    float xRotationV;
    float lookSmoothness = 0.1f;

    CharacterController controller;

    public GameObject rhythmGame;
    public GameObject indicator;

    public Beatscroller beatScroller;

    

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            if(freeze == false)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
            }
            
            
        }
        if(freeze == false)
        {
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);

            yRotation += Input.GetAxis("Mouse X") * lookSensitivity;
            xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
            xRotation = Mathf.Clamp(xRotation, -80, 100);
            currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationV, lookSmoothness);
            currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothness);
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        }
        

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Activator"))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                
                StartCoroutine(Music());
            }
            indicator.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {

        
        
        
            indicator.SetActive(false);
         
            
        
        
    }

    IEnumerator Music()
    {
        Debug.Log("It fucking works");
        rhythmGame.SetActive(true);
        freeze = true;
        beatScroller.hasStarted = true;
        beatScroller.music.Play();
        yield return new WaitForSeconds(17);
        rhythmGame.SetActive(false);
        beatScroller.hasStarted = false;
        beatScroller.NoteMove();
        GameManager.instance.currentScore = 0;
        freeze = false;
        
        
    }
}
