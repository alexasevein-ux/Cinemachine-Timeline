using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EndingCutsceneManager : MonoBehaviour
{
    public PlayableDirector director;
    public GameManager gameManager;

    void Start()
    {
        director.stopped += OnCutsceneFinished;
    }

    void OnCutsceneFinished(PlayableDirector playableDirector)
    {
        gameManager.ShowRestartButton();
    }
}