using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        startButton.onClick.AddListener(() =>
        {
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
    }

    void SetRandomPlayerName()
    {
        nameInputField.text = "Player" + Random.Range(100, 1000);
    }

}
