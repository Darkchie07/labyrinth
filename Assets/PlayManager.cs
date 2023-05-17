using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    [SerializeField] private GameObject finishedCanvas;
    [SerializeField] private TMP_Text finishedText;
    [SerializeField] private TMP_Text countDown;
    [SerializeField] private CustomEvent gameOverEvent;
    [SerializeField] private CustomEvent PlayerWinEvent;
    [SerializeField] private float timer;
    private int coin = 100;

    private void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
            countDown.text = string.Format("{0:00}", timer);
        }
    }

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
