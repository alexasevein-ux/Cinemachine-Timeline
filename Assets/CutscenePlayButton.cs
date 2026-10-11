using UnityEngine;
using UnityEngine.Playables;

public class CutscenePlayButton : MonoBehaviour
{
    [Header("Timeline")]
    public PlayableDirector finalTimeline;

    [Header("Spaceship")]
    public Transform spaceship;

    [Header("UI Objects")]
    public GameObject playButton;
    public GameObject stopButton;
    public GameObject restartButton;
    public GameObject cameraControlsText;

    private Vector3 spaceshipStartPosition;
    private Quaternion spaceshipStartRotation;
    private Vector3 spaceshipStartScale;

    private bool cutscenesPlaying = false;
    private bool stoppingManually = false;

    void Awake()
    {
        // Save the spaceship's original transform.
        if (spaceship != null)
        {
            spaceshipStartPosition = spaceship.localPosition;
            spaceshipStartRotation = spaceship.localRotation;
            spaceshipStartScale = spaceship.localScale;
        }
    }

    void OnEnable()
    {
        if (finalTimeline != null)
        {
            finalTimeline.stopped += OnTimelineStopped;
        }
    }

    void Start()
    {
        ShowGameplayUI();
    }

    void OnDisable()
    {
        if (finalTimeline != null)
        {
            finalTimeline.stopped -= OnTimelineStopped;
        }
    }

    // PLAY CUTSCENES BUTTON
    public void PlayAllCutscenes()
    {
        if (finalTimeline == null)
        {
            Debug.LogWarning("Final Timeline is not assigned.");
            return;
        }

        stoppingManually = true;

        // Stop the previous sequence.
        finalTimeline.Stop();
        finalTimeline.time = 0;

        // Restore the spaceship before replaying.
        ResetSpaceship();

        stoppingManually = false;
        cutscenesPlaying = true;

        ShowCutsceneUI();

        // Begin the sequence from the start.
        finalTimeline.Play();

        Debug.Log("Playing all cutscenes.");
    }

    // RESTART BUTTON
    public void RestartCutscenes()
    {
        Debug.Log("Restarting cutscenes from the beginning.");

        PlayAllCutscenes();
    }

    // STOP CUTSCENES BUTTON
    public void StopAllCutscenes()
    {
        stoppingManually = true;

        if (finalTimeline != null)
        {
            finalTimeline.Stop();
            finalTimeline.time = 0;
        }

        cutscenesPlaying = false;

        ResetSpaceship();
        ShowGameplayUI();

        stoppingManually = false;

        Debug.Log("Cutscenes stopped. Returned to gameplay.");
    }

    // OPTIONAL: Called when the ending cutscene begins.
    public void ShowEndingUI()
    {
        if (!cutscenesPlaying)
            return;

        ShowCutsceneUI();

        Debug.Log("Ending cutscene started.");
    }

    // AUTOMATICALLY CALLED WHEN FINAL TIMELINE STOPS
    private void OnTimelineStopped(PlayableDirector director)
    {
        if (director != finalTimeline)
            return;

        if (stoppingManually || !cutscenesPlaying)
            return;

        cutscenesPlaying = false;

        // Restore the spaceship after the ending.
        ResetSpaceship();

        // Return to normal gameplay UI.
        ShowGameplayUI();

        Debug.Log(
            "Final Timeline finished. " +
            "Spaceship reset and gameplay UI restored."
        );
    }

    // RESET SPACESHIP POSITION
    private void ResetSpaceship()
    {
        if (spaceship == null)
        {
            Debug.LogWarning("Spaceship is not assigned.");
            return;
        }

        spaceship.gameObject.SetActive(true);

        spaceship.localPosition = spaceshipStartPosition;
        spaceship.localRotation = spaceshipStartRotation;
        spaceship.localScale = spaceshipStartScale;

        Debug.Log("Spaceship returned to its starting position.");
    }

    // UI WHILE CUTSCENES ARE PLAYING
    private void ShowCutsceneUI()
    {
        if (playButton != null)
            playButton.SetActive(false);

        if (stopButton != null)
            stopButton.SetActive(true);

        if (restartButton != null)
            restartButton.SetActive(true);

        if (cameraControlsText != null)
            cameraControlsText.SetActive(false);
    }

    // UI DURING NORMAL GAMEPLAY
    private void ShowGameplayUI()
    {
        if (playButton != null)
            playButton.SetActive(true);

        if (stopButton != null)
            stopButton.SetActive(false);

        if (restartButton != null)
            restartButton.SetActive(false);

        if (cameraControlsText != null)
            cameraControlsText.SetActive(true);
    }
}