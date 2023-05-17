using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField] private GameObject finishedCanvas;
    [SerializeField] private TMP_Text finishedText;
    [SerializeField] private CustomEvent gameOverEvent;
    [SerializeField] private CustomEvent PlayerWinEvent;
    private int coin = 100;

    private void OnEnable()
    {
        gameOverEvent.OnInvoked.AddListener(GameOver);
        PlayerWinEvent.OnInvoked.AddListener(PlayerWin);
    }

    private void OnDisable()
    {
        gameOverEvent.OnInvoked.RemoveListener(GameOver);
        PlayerWinEvent.OnInvoked.RemoveListener(PlayerWin);
    }

    public void GameOver()
    {
        finishedText.text = "You Failed";
        finishedCanvas.SetActive(true);
    }

    public void PlayerWin()
    {
        finishedText.text = "You Win! \n Score: " + GetScore();
        finishedCanvas.SetActive(true);
    }

    private int GetScore()
    {
        return coin * 10;
    }
}
