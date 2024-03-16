using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCController : MonoBehaviour
{
    private NPC npc;
    public float speed = 5.0f;
    private Rigidbody rb;
    private PlayerControllerInput playerControllerInput;
    private Vector2 movementInput;
    private Vector3 currentMovement;
    bool isMove = false;
    private Camera mainCamera;
    private Vector3 cameraPos;
    private Quaternion cameraRot;
    private void Awake()
    {
        npc = new NPC();
        npc.name = "NPC";
        rb = GetComponent<Rigidbody>();
        playerControllerInput = new PlayerControllerInput();
        playerControllerInput.PlayerController.Movement.started += Move;
        playerControllerInput.PlayerController.Movement.performed += Move;
        playerControllerInput.PlayerController.Movement.canceled += Move;

    }
    private void Start()
    {
        mainCamera = Camera.main;
        cameraPos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z - 5);
        cameraRot = Quaternion.Euler(30, 0, 0);
        mainCamera.transform.position = cameraPos;
        mainCamera.transform.rotation = cameraRot;
    }
    void FixedUpdate()
    {
        if (isMove)
        {
            rb.MovePosition(transform.position + currentMovement * speed * Time.fixedDeltaTime);
            Debug.Log(npc.name + " is moving");
            if(Input.GetKey(KeyCode.LeftShift))
            {
                speed = 10.0f;
            }else
            {
                speed = 5.0f;
            }
        }
    }
    private void LateUpdate()
    {
        cameraPos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z - 5);
        cameraRot = Quaternion.Euler(30, 0, 0);
        mainCamera.transform.position = cameraPos;
        mainCamera.transform.rotation = cameraRot;
    }
    void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        currentMovement.x = movementInput.x;
        currentMovement.z = movementInput.y;
        isMove = movementInput.x != 0 || movementInput.y != 0;
    }

    private void OnEnable()
    {
        playerControllerInput.Enable();

    }
    private void OnDisable()
    {
        playerControllerInput.Disable();

    }
}

public class NPC
{
    public String name { get; set; }

}
