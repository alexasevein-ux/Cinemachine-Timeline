using UnityEngine;
using UnityEngine.Playables;

public class InGameCutsceneTrigger : MonoBehaviour
{
    public PlayableDirector director;

    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasPlayed)
            return;

        if (other.CompareTag("Player"))
        {
            hasPlayed = true;

            director.Play();
        }
    }
}