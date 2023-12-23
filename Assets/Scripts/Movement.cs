using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public float gravity = -9.81f; //gravity = 9.81m/s^2
    private CharacterController characterController;
    private Camera camera;

    private float pitch = 0.0f; // Vertical rotation angle
    private float verticalVelocity = 0.0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to the center of the screen
    }

    void Update()
    {
        // Camera rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the character horizontally
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera vertically
        pitch -= mouseY; // Inverting the y-axis for natural movement
        pitch = Mathf.Clamp(pitch, -90f, 90f); // Clamping to prevent over-rotation

        camera.transform.localEulerAngles = new Vector3(pitch, 0f, 0f);

        // Character movement
        float x_movement = Input.GetAxis("Horizontal");
        float y_movement = Input.GetAxis("Vertical");

        Vector3 forward = camera.transform.forward;
        Vector3 right = camera.transform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * y_movement + right * x_movement).normalized;

        // Apply gravity
        if (characterController.isGrounded)
        {
            verticalVelocity = 0; // Reset vertical velocity if on ground
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime; // Apply gravity when not grounded
        }

        // Combine movement and gravity, then apply
        Vector3 finalMovement = moveDirection * speed + Vector3.up * verticalVelocity;
        characterController.Move(finalMovement * Time.deltaTime);
    }
}