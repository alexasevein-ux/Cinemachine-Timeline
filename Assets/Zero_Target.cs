using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Zero_Target : MonoBehaviour
{
    [SerializeField] private GameObject VC1;

    [SerializeField] private GameObject _target01;
    [SerializeField] private GameObject _target02;

    private bool _firstTarget = true;


    void Start()
    {
        // Start by following Target 1
        VC1.GetComponent<CinemachineVirtualCamera>().Follow = _target01.transform;

        VC1.GetComponent<CinemachineVirtualCamera>().LookAt = _target01.transform;
    }


    void Update()
    {
        // Press R to switch targets
        if (Input.GetKeyDown(KeyCode.R))
        {
            SwitchTarget();
        }


        // Press Space to zoom the camera
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float FOV = VC1.GetComponent<CinemachineVirtualCamera>()
                .m_Lens.FieldOfView -= 20;

            if (FOV < 10)
            {
                VC1.GetComponent<CinemachineVirtualCamera>()
                .m_Lens.FieldOfView = 60;
            }
        }
    }


    private void SwitchTarget()
    {
        if (_firstTarget)
        {
            // Switch to Target 2
            VC1.GetComponent<CinemachineVirtualCamera>().Follow = _target02.transform;

            VC1.GetComponent<CinemachineVirtualCamera>().LookAt = _target02.transform;

            _firstTarget = false;
        }
        else
        {
            // Switch back to Target 1
            VC1.GetComponent<CinemachineVirtualCamera>().Follow = _target01.transform;

            VC1.GetComponent<CinemachineVirtualCamera>().LookAt = _target01.transform;

            _firstTarget = true;
        }
    }
}