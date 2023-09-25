using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TableController : MonoBehaviour
{
    // Input
    public float xMouseSensitivity = 30.0f;
    public float zMouseSensitivity = 30.0f;

    // Table rotations
    private float rotX = 0.0f;
    private float rotZ = 0.0f;

    // Rotation clamps
    public float maxX = 20f;
    public float maxZ = 20f;

    public void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MoveRectangle(InputAction.CallbackContext ctx)
    {
        rotX -= ctx.ReadValue<Vector2>().y * xMouseSensitivity * 0.02f;
        rotZ += ctx.ReadValue<Vector2>().x * zMouseSensitivity * 0.02f;
    }

    public void Update()
    {
        // Check if game is paused
        if (Time.timeScale <= 0f)
            return;

        // Clamp the X rotation
        if (rotX < -maxX)
            rotX = -maxX;
        else if (rotX > maxX)
            rotX = maxX;

        // Clamp the Z rotation
        if (rotZ < -maxZ)
            rotZ = -maxZ;
        else if (rotZ > maxZ)
            rotZ = maxZ;

        transform.rotation = Quaternion.Euler(rotX, 0 , rotZ);
    }

    public void ResetRotation()
    {
        rotX = 0.0f; rotZ = 0.0f;
    }
}
