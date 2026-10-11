using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class IdleCinematicController : MonoBehaviour
{
    public float idleTime = 5f;

    public CameraManager cameraManager;

    private float idleTimer;
    private bool cinematicPlaying = false;

    void Start()
    {
        idleTimer = 0f;
    }

    void Update()
    {
        CheckPlayerInput();

        if (!cinematicPlaying)
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= idleTime)
            {
                StartCinematic();
            }
        }
    }

    void CheckPlayerInput()
    {
        bool keyboardInput = Input.anyKeyDown;

        bool mouseMovement = Mathf.Abs(Input.GetAxis("Mouse X")) > 0.01f || Mathf.Abs(Input.GetAxis("Mouse Y")) > 0.01f;

        if (keyboardInput || mouseMovement)
        {
            idleTimer = 0f;

            if (cinematicPlaying)
            {
                StopCinematic();
            }
        }
    }

    void StartCinematic()
    {
        if (cameraManager == null)
        {
            Debug.LogError("Camera Manager is not assigned to IdleCinematicController.");
            return;
        }

        cinematicPlaying = true;

        cameraManager.StartCinematic();

        InvokeRepeating(nameof(NextCinematicCamera), 3f, 3f);
    }

    void StopCinematic()
    {
        cinematicPlaying = false;

        CancelInvoke();

        idleTimer = 0f;

        if (cameraManager != null)
        {
            cameraManager.StopCinematic();
        }
    }

    void NextCinematicCamera()
    {
        if (cameraManager != null)
        {
            cameraManager.NextCinematicCamera();
        }
    }
}