using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffCamera : MonoBehaviour
{
    [SerializeField] private GameObject[] _cameras;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //turn off camera 1 and 2
            _cameras[0].SetActive(false);
            _cameras[1].SetActive(false);
        }  
    }
}
