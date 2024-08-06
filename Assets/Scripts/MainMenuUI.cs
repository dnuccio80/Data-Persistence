using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;

    //[Serializable]
    //public class BestPlayerData
    //{
    //    public int score;
    //    public string playerName;
    //}

    private void Awake()
    {
        startButton.onClick.AddListener(() =>
        {
            PlayerData.SetPlayerName(nameInputField.text);
            SceneManager.LoadScene(1);
        });

        quitButton.onClick.AddListener(() =>
        {
           #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
           #else
            Application.Quit();
           #endif
        });
    }

    private void Start()
    {
        SetRandomPlayerName();
        LoadData();
    }

    void SetRandomPlayerName()
    {
        nameInputField.text = "Player" + UnityEngine.Random.Range(100, 1000);
    }

    void LoadData()
    {
        string path = Application.persistentDataPath + MainManager.DATA_PATH;

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);

            BestPlayerData bestPlayerData = JsonUtility.FromJson<BestPlayerData>(json);

            UpdateBestScoreText(bestPlayerData.playerName, bestPlayerData.score);
        } else
        {
            UpdateBestScoreText("", 0);
        }
    }

    void UpdateBestScoreText(string playerName, int score)
    {
        bestScoreText.text = "Best Score: " + playerName + " : " + score;
    }

}
