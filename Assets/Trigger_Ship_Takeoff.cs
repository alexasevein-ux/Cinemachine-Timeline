using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Trigger_Ship_Takeoff : MonoBehaviour
{
    [SerializeField] private PlayableDirector _director;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _director.Play();
        }
    }
}
