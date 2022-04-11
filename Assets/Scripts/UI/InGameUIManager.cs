using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    public Image PauseImage;
    public Sprite pause, paused;

    private void Start()
    {
        GameStatusEvent.onGameStarted += OnGamestarted;
        GameStatusEvent.onLevelEnded += OnLevelEnded;
        GameStatusEvent.onGamePaused += OnGamePaused;
    }

    private void OnDisable()
    {
        GameStatusEvent.onGameStarted -= OnGamestarted;
        GameStatusEvent.onLevelEnded -= OnLevelEnded;
        GameStatusEvent.onGamePaused -= OnGamePaused;
    }


    private void OnLevelEnded()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnGamePaused()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }



    private void OnGamestarted()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }



    public void PauseGame()
    {
        GameStatusEvent.Status.GamePaused();
        Time.timeScale = 0f;
    }
}
