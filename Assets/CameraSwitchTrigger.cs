using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchTrigger : MonoBehaviour
{
    public CameraManager cameraManager;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (cameraManager == null)
        {
            Debug.LogError("Camera Manager is not assigned to CameraSwitchTrigger.");
            return;
        }

        cameraManager.NextCinematicCamera();
    }
}