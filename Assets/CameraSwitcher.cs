using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera exteriorCamera;
    public Camera cockpitCamera;

    public GameObject shipModel;
    public GameObject cockpitModel;

    private bool cockpitView = false;

    void Start()
    {
        SetExteriorView();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            cockpitView = !cockpitView;

            if (cockpitView)
            {
                SetCockpitView();
            }
            else
            {
                SetExteriorView();
            }
        }
    }

    void SetExteriorView()
    {
        exteriorCamera.enabled = true;
        cockpitCamera.enabled = false;

        shipModel.SetActive(true);
        cockpitModel.SetActive(false);
    }

    void SetCockpitView()
    {
        exteriorCamera.enabled = false;
        cockpitCamera.enabled = true;

        shipModel.SetActive(false);
        cockpitModel.SetActive(true);
    }
}