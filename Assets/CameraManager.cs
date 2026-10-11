using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraManager : MonoBehaviour
{
    [Header("Main Cameras")]
    [SerializeField] private CinemachineVirtualCamera _exteriorCamera;
    [SerializeField] private CinemachineVirtualCamera _interiorCamera;

    [Header("Cinematic Virtual Cameras")]
    [SerializeField] private CinemachineVirtualCamera _vcam1;
    [SerializeField] private CinemachineVirtualCamera _vcam2;
    [SerializeField] private CinemachineVirtualCamera _vcam3;
    [SerializeField] private CinemachineVirtualCamera _vcam4;
    [SerializeField] private CinemachineVirtualCamera _vcam5;

    [Header("Timeline")]
    [SerializeField] private PlayableDirector _playableDirector;

    private CinemachineVirtualCamera[] _cameras;

    private int _currentCameraIndex = 0;

    // Tracks whether we are using the interior camera
    private bool _usingInteriorCamera = false;

    // Prevent normal camera switching during a cinematic
    private bool _cinematicPlaying = false;


    // --------------------------------------------------
    // AWAKE
    // --------------------------------------------------

    private void Awake()
    {
        _cameras = new CinemachineVirtualCamera[]
        {
            _exteriorCamera,  // 0
            _interiorCamera,  // 1
            _vcam1,           // 2
            _vcam2,           // 3
            _vcam3,           // 4
            _vcam4,           // 5
            _vcam5            // 6
        };
    }


    // --------------------------------------------------
    // START
    // --------------------------------------------------

    private void Start()
    {
        // Start with Exterior Camera
        _currentCameraIndex = 0;
        _usingInteriorCamera = false;

        SetActiveCamera(_currentCameraIndex);
    }


    // --------------------------------------------------
    // UPDATE
    // --------------------------------------------------

    private void Update()
    {
        // R switches ONLY between Exterior and Interior.
        // Do not allow switching while a cinematic is playing.
        if (Input.GetKeyDown(KeyCode.R) && !_cinematicPlaying)
        {
            ToggleMainCamera();
        }
    }


    // --------------------------------------------------
    // TOGGLE EXTERIOR / INTERIOR
    // --------------------------------------------------

    private void ToggleMainCamera()
    {
        _usingInteriorCamera = !_usingInteriorCamera;

        if (_usingInteriorCamera)
        {
            // Interior Camera
            _currentCameraIndex = 1;
        }
        else
        {
            // Exterior Camera
            _currentCameraIndex = 0;
        }

        SetActiveCamera(_currentCameraIndex);
    }


    // --------------------------------------------------
    // SET ACTIVE CAMERA
    // --------------------------------------------------

    private void SetActiveCamera(int cameraIndex)
    {
        // Lower priority of every camera
        for (int i = 0; i < _cameras.Length; i++)
        {
            if (_cameras[i] != null)
            {
                _cameras[i].Priority = 10;
            }
        }

        // Give selected camera highest priority
        if (cameraIndex >= 0 &&
            cameraIndex < _cameras.Length &&
            _cameras[cameraIndex] != null)
        {
            _cameras[cameraIndex].Priority = 20;
        }
    }


    // --------------------------------------------------
    // START CINEMATIC
    // --------------------------------------------------

    public void StartCinematic()
    {
        _cinematicPlaying = true;

        // Start with VCam1
        _currentCameraIndex = 2;

        SetActiveCamera(_currentCameraIndex);

        // Start Timeline if assigned
        if (_playableDirector != null)
        {
            _playableDirector.Play();
        }
    }


    // --------------------------------------------------
    // NEXT CINEMATIC CAMERA
    // --------------------------------------------------

    public void NextCinematicCamera()
    {
        // Only cycle through VCam1 - VCam5
        _currentCameraIndex++;

        // VCam1 = 2
        // VCam2 = 3
        // VCam3 = 4
        // VCam4 = 5
        // VCam5 = 6

        if (_currentCameraIndex > 6)
        {
            _currentCameraIndex = 2;
        }

        SetActiveCamera(_currentCameraIndex);
    }


    // --------------------------------------------------
    // STOP CINEMATIC
    // --------------------------------------------------

    public void StopCinematic()
    {
        // Stop Timeline
        if (_playableDirector != null)
        {
            _playableDirector.Stop();
        }

        _cinematicPlaying = false;

        // Return to Exterior Camera
        _usingInteriorCamera = false;
        _currentCameraIndex = 0;

        SetActiveCamera(_currentCameraIndex);
    }
}