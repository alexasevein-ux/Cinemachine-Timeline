using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EndGameTrigger : MonoBehaviour
{
    public PlayableDirector endingDirector;
    public ShipControls shipControls;

    private bool hasEnded;

    private void OnTriggerEnter(Collider other)
    {
        if (hasEnded)
            return;

        if (other.CompareTag("Player"))
        {
            hasEnded = true;

            shipControls.canControl = false;

            endingDirector.Play();
        }
    }
}