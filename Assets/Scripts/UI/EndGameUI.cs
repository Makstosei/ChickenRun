using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUI : MonoBehaviour
{
    public Object NextLevel,Mainmenu;


    private void Start()
    {
        GameStatusEvent.onLevelEnded += OnLevelEnded;
    }


    private void OnDisable()
    {
        GameStatusEvent.onLevelEnded -= OnLevelEnded;
    }

    private void OnLevelEnded()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void NextLevelButton()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1==2)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
       
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

}
