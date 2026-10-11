using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Cam_Bool : MonoBehaviour
{
    [SerializeField] private GameObject VC1;
    [SerializeField] private GameObject VC2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            VC1.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            VC1.SetActive(true);
        }
    }
}
