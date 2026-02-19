using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 5f;
    public float runSpeed = 7f;
    public float jumpHeight = 5f;

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
}
