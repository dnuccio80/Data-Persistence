using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{


    private void Start()
    {
        MainManager.Instance.OnGameOver += MainManager_OnGameOver;
        Hide();
    }

    private void MainManager_OnGameOver(object sender, System.EventArgs e)
    {
        Show();
    }

    void Show()
    {
        gameObject.SetActive(true);

    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
    

}
