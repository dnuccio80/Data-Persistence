using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private void Start()
    {
        MainManager.Instance.OnPointAdded += MainManager_OnPointAdded;
    }

    private void MainManager_OnPointAdded(object sender, MainManager.OnPointAddedEventArgs e)
    {
        UpdateVisual(e.points);
    }

    void UpdateVisual(int score)
    {
        scoreText.text = "Score: " + score.ToString();
        bestScoreText.text = "Best Score: Name : " + score.ToString();

    }
}
