using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    [Header("Restart Button")]
    public GameObject restartButton;

    [Header("Gameplay Cameras")]
    public CinemachineVirtualCamera cockpitCamera;
    public CinemachineVirtualCamera exteriorCamera;

    [Header("Cinematic Cameras")]
    public CinemachineVirtualCamera[] cinematicCameras;

    [Header("Timeline")]
    public PlayableDirector timelineDirector;

    private bool usingCockpitCamera = true;
    private int currentCinematicCamera = 0;
    private bool cinematicPlaying = false;

    void Start()
    {
        // Restart button must stay hidden until the ending cutscene finishes.
        if (restartButton != null)
        {
            restartButton.SetActive(false);
        }

        // Start with cockpit camera.
        SetGameplayCamera(true);

        // Cinematic cameras should not take control at startup.
        SetAllCinematicCamerasOff();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R key detected!");

            if (!cinematicPlaying)
            {
                SetGameplayCamera(!usingCockpitCamera);
            }
            else
            {
                Debug.LogWarning("Cannot switch cameras because cinematicPlaying is true.");
            }
        }
    }

    public void BeginTimelineCutscene()
    {
        cinematicPlaying = true;
    }

    public void EndTimelineCutscene()
    {
        cinematicPlaying = false;

        SetAllCinematicCamerasOff();
        SetGameplayCamera(usingCockpitCamera);
    }

    public void SetGameplayCamera(bool useCockpit)
    {
        usingCockpitCamera = useCockpit;

        if (cockpitCamera != null)
        {
            cockpitCamera.Priority = useCockpit ? 20 : 0;
        }

        if (exteriorCamera != null)
        {
            exteriorCamera.Priority = useCockpit ? 0 : 20;
        }

        Debug.Log("Camera switched to: " + (useCockpit ? "Cockpit Camera" : "Exterior Camera"));
    }

    public void StartCinematic()
    {
        cinematicPlaying = true;

        // Lower gameplay camera priorities.
        if (cockpitCamera != null)
        {
            cockpitCamera.Priority = 0;
        }

        if (exteriorCamera != null)
        {
            exteriorCamera.Priority = 0;
        }

        currentCinematicCamera = 0;
        SetCinematicCamera(currentCinematicCamera);
    }

    public void StopCinematic()
    {
        cinematicPlaying = false;

        SetAllCinematicCamerasOff();

        // Return to whichever gameplay camera was previously selected.
        SetGameplayCamera(usingCockpitCamera);
    }

    public void NextCinematicCamera()
    {
        if (cinematicCameras == null ||
            cinematicCameras.Length == 0)
        {
            return;
        }

        currentCinematicCamera++;

        if (currentCinematicCamera >= cinematicCameras.Length)
        {
            currentCinematicCamera = 0;
        }

        SetCinematicCamera(currentCinematicCamera);
    }

    private void SetCinematicCamera(int cameraIndex)
    {
        SetAllCinematicCamerasOff();

        if (cinematicCameras != null &&
            cameraIndex >= 0 &&
            cameraIndex < cinematicCameras.Length &&
            cinematicCameras[cameraIndex] != null)
        {
            cinematicCameras[cameraIndex].Priority = 30;
        }
    }

    private void SetAllCinematicCamerasOff()
    {
        if (cinematicCameras == null)
        {
            return;
        }

        foreach (CinemachineVirtualCamera camera in cinematicCameras)
        {
            if (camera != null)
            {
                camera.Priority = 0;
            }
        }
    }

    // Called by the Signal at the end of EndingCutscene.
    public void ShowRestartButton()
    {
        if (restartButton != null)
        {
            restartButton.SetActive(true);
        }
    }

    // Called by the Restart UI button.
    public void RestartGame()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void ReportCutscene(string cutsceneName)
    {
        Debug.Log("Now playing: " + cutsceneName);
    }

} // End of GameManager class