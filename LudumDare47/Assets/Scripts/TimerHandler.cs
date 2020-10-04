using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerHandler : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private int totalTime;

    private float timer;

    public bool TimerActive { get; set; }

    private void Start()
    {
        LevelHandler.Instance.LoopIncremented += NewLoop;
        timer = totalTime;
    }

    private void NewLoop()
    {
        TimerActive = true;
    }

    void Update()
    {
        if (!TimerActive)
        {
            return;
        }

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            LevelHandler.Instance.GameOver();
        }

        SetText();
    }

    private void SetText()
    {
        timerText.text = "Crystals " + LevelHandler.Instance.Crystals + "/5 \nPortal Closes in: " + (int)timer + "s"; 
    }
}
