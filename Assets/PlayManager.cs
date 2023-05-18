using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayManager : MonoBehaviour
{
    public AudioClip timesup;
    public AudioClip fail;
    public AudioClip win;
    public UnityEvent onAwake = new UnityEvent();
    public UnityEvent onFinish = new UnityEvent();
    [SerializeField] private GameObject finishedCanvas;
    [SerializeField] private TMP_Text finishedText;
    [SerializeField] private TMP_Text countDown;
    [SerializeField] private CustomEvent gameOverEvent;
    [SerializeField] private CustomEvent PlayerWinEvent;
    [SerializeField] private float timer;
    private int coin = 100;
    private bool isDone = false;

    private void Awake()
    {
        onAwake.Invoke();
    }

    private void Update()
    {
        if (timer >= 0 && !isDone)
        {
            timer -= Time.deltaTime;
            countDown.text = string.Format("{0:00}", timer);
        }else if (timer <= 0 && !isDone)
        {
            isDone = true;
            finishedText.text = "Time's Up!\nYou Failed";
            SoundManager.Instance.playSFX(timesup);
            finishedCanvas.SetActive(true);
            onFinish.Invoke();
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
        SoundManager.Instance.playSFX(fail);
        isDone = true;
        finishedText.text = "You Failed";
        finishedCanvas.SetActive(true);
        onFinish.Invoke();
    }

    public void PlayerWin()
    {
        SoundManager.Instance.playSFX(win);
        isDone = true;
        finishedText.text = "You Win!";
        finishedCanvas.SetActive(true);
        onFinish.Invoke();
    }

    private int GetScore()
    {
        return coin * 10;
    }
}
