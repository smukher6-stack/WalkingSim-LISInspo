using UnityEngine;
using UnityEngine.InputSystem;
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

}
