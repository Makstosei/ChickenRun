using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FailUIManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText, FailScore;




    private void OnEnable()
    {
        GameStatusEvent.onHitTrap += onHitTrap;
        GameStatusEvent.onGameStarted += onGameStared;
    }
    private void OnDisable()
    {
        GameStatusEvent.onHitTrap -= onHitTrap;
        GameStatusEvent.onGameStarted -= onGameStared;
    }

    private void onGameStared()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void onHitTrap()
    {
        FailScore.text = ScoreText.text;
        transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 0;
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




}
