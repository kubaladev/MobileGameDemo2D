using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PostGameScoreManager: MonoBehaviour
{
    [SerializeField] TMP_Text actualScoreTxt, highScoreTxt, thankYouText;
    void SetScoreVisual()
    {
        int actualScore = PlayerPrefs.GetInt("actualScore");
        int highScore = PlayerPrefs.GetInt("highScore");
        if(actualScore > highScore)
        {
            thankYouText.text = "NEW HIGH SCORE!";
            highScore = actualScore;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        actualScoreTxt.text = actualScore.ToString();
        highScoreTxt.text = highScore.ToString();
    }
    private void Awake()
    {
        SetScoreVisual();
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}
