using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreTxt, escapeTxt;
    [SerializeField] int maxEnemiesToEscape = 3;
    int score = 0;
    int escapedEnemies = 0;


    // Register Enemy is called in respond to OnCreatedEnemy event
    public void RegisterEnemy(Enemy enemy)
    {
        enemy.OnEnemyKilled += UpdateScore;
        enemy.OnEnemyEscaped += UpdateEscape;
    }
    public void UpdateScore(Enemy enemy)
    {
        score += enemy.score;
        scoreTxt.text = score.ToString("D5");
    }
    public void UpdateEscape(Enemy enemy)
    {
        escapedEnemies++;
        escapeTxt.text = escapedEnemies + " / " + maxEnemiesToEscape;
        if (escapedEnemies >= maxEnemiesToEscape)
        {
            LevelOver();
        }
    }
    public void LevelOver()
    {
        PlayerPrefs.SetInt("actualScore", score);
        SceneManager.LoadScene("EndScreen");
    }
}
