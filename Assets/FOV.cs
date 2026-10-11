using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FOV : MonoBehaviour
{
    private CinemachineVirtualCamera _cam;
    // Start is called before the first frame update
    void Start()
    {
        _cam = GetComponent<CinemachineVirtualCamera>();
        _cam.m_Lens.FieldOfView = 40;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
