using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI testNameText;

    private void Start()
    {
        MainManager.Instance.OnPointAdded += MainManager_OnPointAdded;
        MainManager.Instance.OnGameOver += MainManager_OnGameOver;
        testNameText.text = PlayerData.GetPlayerName();
        UpdateBestScore();
    }

    private void MainManager_OnGameOver(object sender, System.EventArgs e)
    {
        UpdateBestScore();
    }

    private void MainManager_OnPointAdded(object sender, MainManager.OnPointAddedEventArgs e)
    {
        UpdateVisual(e.points);
    }

    void UpdateVisual(int score)
    {
        scoreText.text = "Score: " + score.ToString();
        UpdateBestScore();
    }

    void UpdateBestScore()
    {
        BestPlayerData bestPlayerData = MainManager.Instance.GetBestPlayerData();

        if (bestPlayerData != null) bestScoreText.text = "Best Score: " + bestPlayerData.playerName + " : " + bestPlayerData.score;
        else bestScoreText.text = "Best Score Text : :";
    }
}
