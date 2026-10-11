using UnityEngine;
using UnityEngine.Playables;

public class TriggeredCutsceneVolume : MonoBehaviour
{
    public PlayableDirector triggeredCutscene;
    public bool triggerOnlyOnce = true;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (triggerOnlyOnce && hasTriggered)
            return;

        if (triggeredCutscene == null)
        {
            Debug.LogWarning("Triggered Cutscene is not assigned!");
            return;
        }

        hasTriggered = true;

        triggeredCutscene.time = 0;
        triggeredCutscene.Play();

        Debug.Log("Robot entered the triggered cutscene!");
    }
}