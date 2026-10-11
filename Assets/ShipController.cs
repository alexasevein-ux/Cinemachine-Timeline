using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [Header("Rotation")]
    public float pitchSpeed = 50f;
    public float yawSpeed = 50f;
    public float rollSpeed = 70f;

    [Header("Speed")]
    public float acceleration = 10f;
    public float deceleration = 5f;
    public float maxSpeed = 30f;

    private float currentSpeed;

    void Update()
    {
        HandleRotation();
        HandleSpeed();
        MoveShip();
    }

    void HandleRotation()
    {
        // Pitch
        float pitch = Input.GetAxis("Vertical") * pitchSpeed * Time.deltaTime;

        // Yaw
        float yaw = Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;

        // Roll
        float roll = 0f;

        if (Input.GetKey(KeyCode.Q))
        {
            roll = rollSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E))
        {
            roll = -rollSpeed * Time.deltaTime;
        }

        transform.Rotate(-pitch, yaw, roll);
    }

    void HandleSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= deceleration * Time.deltaTime;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);
    }

    void MoveShip()
    {
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
}