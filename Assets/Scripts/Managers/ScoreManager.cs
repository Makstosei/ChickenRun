using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public  TextMeshProUGUI ScoreText;
    public  int Score;



    public  void AddScore(int addScore)
    {
        Score += addScore;
        ScoreText.text = Score.ToString();
    }

    public void DecreaseScore(int decreasedScore)
    {
        Score -= decreasedScore;
        ScoreText.text = Score.ToString();

    }


}
