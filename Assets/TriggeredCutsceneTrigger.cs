using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggeredCutsceneTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector cutsceneDirector;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasPlayed)
            return;

        if (other.CompareTag("Player"))
        {
            hasPlayed = true;

            cutsceneDirector.time = 0;
            cutsceneDirector.Play();
        }
    }
}
