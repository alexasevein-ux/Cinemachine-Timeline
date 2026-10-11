using UnityEngine;
using UnityEngine.Playables;

public class CutsceneSequenceController : MonoBehaviour
{
    public PlayableDirector triggeredCutscene;
    public PlayableDirector endingCutscene;

    private void OnEnable()
    {
        if (triggeredCutscene != null)
            triggeredCutscene.stopped += OnTriggeredCutsceneStopped;
    }

    private void OnDisable()
    {
        if (triggeredCutscene != null)
            triggeredCutscene.stopped -= OnTriggeredCutsceneStopped;
    }

    private void OnTriggeredCutsceneStopped(PlayableDirector director)
    {
        if (endingCutscene != null)
        {
            endingCutscene.time = 0;
            endingCutscene.Play();
        }
    }
}