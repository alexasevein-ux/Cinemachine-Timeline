using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public CameraManager cameraManager;

    private void OnTriggerEnter(Collider other)
    {
        if (cameraManager == null)
        {
            Debug.LogError("Camera Manager is not assigned to CameraTrigger.");
            return;
        }

        cameraManager.StartCinematic();
    }

    private void OnTriggerExit(Collider other)
    {
        if (cameraManager == null)
        {
            return;
        }

        cameraManager.StopCinematic();
    }
}