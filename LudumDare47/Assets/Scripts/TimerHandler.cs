using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerHandler : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private int totalTime;
    [SerializeField] private AudioSource music;

    private float timer;

    public bool TimerActive { get; set; }

    private void Start()
    {
        LevelHandler.Instance.LoopIncremented += NewLoop;
        timer = totalTime;
    }

    private void NewLoop()
    {
        if (!TimerActive)
        {
            music.Play();
        }
        else
        {
            music.pitch += 0.1f;
        }
        TimerActive = true;
    }

    void Update()
    {
        LevelHandler.Instance.TimeLeft = (int)timer;
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
        if (LevelHandler.Instance.Crystals >= 5)
        {
            timerText.text = "GET TO THE PORTAL!\nDimension Collapse in: " + (int)timer + "s";
        }
        else
        {
            timerText.text = "Crystals " + LevelHandler.Instance.Crystals + "/5 \nDimension Collapse in: " + (int)timer + "s";
        }
    }
}
