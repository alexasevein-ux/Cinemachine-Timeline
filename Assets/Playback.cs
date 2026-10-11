using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Playback : MonoBehaviour
{
    private PlayableDirector _director;
    [SerializeField] private float _timeToAdvance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            _director.time = _timeToAdvance;
            _director.Play();
        }
    }

        public void PauseTimeline()
        {
            _director.Play();
        }
        
        public void PlayTimeline()
        {
            _director.Play();
        }

        public void SkipTo5()
        {
            _director.time = 5;
            _director.Play();
        }
}
