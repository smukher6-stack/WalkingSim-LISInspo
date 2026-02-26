using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 5f;
    public float runSpeed = 7f;
    public float jumpHeight = 5f;

    bool isRunning;
    bool isJumping;
   
    public Transform cameraTransform;
    public float lookSensitivity = 1f;

    private CharacterController cC;
    private Vector2 moveInput;
    private Vector2 lookInput;

    private float verticalVelocity;
    private float gravity = -20f;

    private float pitch;
    private float yaw;

    private GameObject currentTarget;
    public Image reticleImage;
    private bool pressButton;
    

    public static event Action<NPCData> OnDialogueReqested;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        cC = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        reticleImage = GameObject.Find("reticle").GetComponent<Image>();

        reticleImage.color = Color.aliceBlue;
    }

    // Update is called once per frame
    void Update()
    {
        handleMovement();
        handleLook();
    }
    private void handleLook()
    {

        float yaw = lookInput.x *lookSensitivity;
        float pitchDelta = lookInput.y *lookSensitivity;

        transform.Rotate(Vector3.up * yaw);
        pitch -= pitchDelta;
        pitch = Mathf.Clamp(pitch, -90, -90);
        cameraTransform.localRotation = Quaternion.Euler(pitch, 0,0);
    }

    private void handleMovement()
    {
        bool grounded = cC.isGrounded;
        Debug.Log("is grounded" + grounded);

        if(grounded && verticalVelocity <= 0f)
        {

            verticalVelocity = -2f;
        }

        float currentSpeed = walkSpeed;

        if (isRunning)
        {
            currentSpeed = runSpeed;
        }

        else if(!isRunning) 
        {
            currentSpeed = walkSpeed;
        }

        Vector3 move = transform.right * moveInput.x * currentSpeed + transform.forward * moveInput.y * currentSpeed;

        if(isJumping && grounded)
        {

            verticalVelocity = Mathf.Sqrt(f: jumpHeight * -2f * gravity);
        }
        else
        {
            isJumping = false;
        }

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 velocity = Vector3.up *verticalVelocity;

        cC.Move((move + velocity) * Time.deltaTime);
    }

    void CheckInteract()
    {
        //reset reticle image to normal color first
        if (reticleImage != null) reticleImage.color = new Color(0, 0, 0, .7f);
        //make a ray that goes straight out of the camera(center of screen)
        //players eyesight
        Ray ray = new Ray(cameraTransform.position, cameraTransform.forward);
       
        //asking unity if it hit something within 3 units
        //hit stores what we hit like the collider
        
        //if we hit something tagged interactable
        if (Physics.Raycast(ray, out RaycastHit hit, 3f))
        {
            //store the object so we can destroy or do whatever when the player clicks
            currentTarget = hit.collider.gameObject;
            if (reticleImage != null)
            {
                reticleImage.color = Color.red;
            }
        }

        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * 3, Color.blue);
    }

    void HandleInteract()
    {
        //if the player did not press interact this frame do nothing
        if (!pressButton) return;
        //consume the input so one click only triggers one interactions
        //this changes next frame
        pressButton = false;
        if (currentTarget == null) return;
        Destroy(currentTarget);
        //clear target reference after destroying
        currentTarget = null;

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context) 
    { 
    
    lookInput = context.ReadValue<Vector2>();
    
    }

    public void onJump(InputAction.CallbackContext context)
    {
        if (context.performed) isJumping = true;
    }
    
    public void onSprint(InputAction.CallbackContext context)
    {
        isRunning = context.ReadValueAsButton();
    }

    public void onInteract(InputAction.CallbackContext context)
    {
        if (context.performed) pressButton = true;
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Character Collided with:" + hit.gameObject.name);
    }

    public void RequestDialoge(NPCData nPCData)
    {
        OnDialogueReqested?.Invoke(nPCData);

    }

}
