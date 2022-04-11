using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameManager : MonoBehaviour
{
    public Object NextLevel;


    private void OnEnable()
    {
        GameStatusEvent.onGamePaused += onGamePaused;
        GameStatusEvent.onGameStarted += onGameStared;
    }
    private void OnDisable()
    {
        GameStatusEvent.onGamePaused -= onGamePaused;
        GameStatusEvent.onGameStarted -= onGameStared;
    }

    private void onGameStared()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void onGamePaused()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void ContinuePLaying()
    {
        GameStatusEvent.Status.GameStared();
        Time.timeScale = 1;
        
    }


}
