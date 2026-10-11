using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbBlowingOut : MonoBehaviour
{
    [SerializeField] public GameObject _director;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            _director.SetActive(true);
        }
    }
}
