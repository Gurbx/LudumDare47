using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public static LevelHandler Instance;

    public List<GameObject> crystalDisplay;

    public delegate void LevelHandlerEventHandler();

    public event LevelHandlerEventHandler LoopIncremented;
    public event LevelHandlerEventHandler CrystalCollected;

    public int LoopNr { get; private set; }
    public int Crystals { get; private set; }
    public int TimeLeft { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            GameObject.Destroy(this);
            return;
        }

        Instance = this;
        LoopNr = 0;
        Crystals = 0;
    }

    public void IncrementLoop()
    {
        if (Crystals >= 5)
        {
            sceneIndex = 2;
            ChangeScene();
        }

        LoopNr++;
        if (LoopIncremented != null)
        {
            LoopIncremented.Invoke();
        }
    }

    public void IncrementCrystals()
    {
        Crystals++;
        if (CrystalCollected != null)
        {
            CrystalCollected.Invoke();
        }

        for (int i = 0; i < crystalDisplay.Count; i++)
        {
            if (i < Crystals)
            {
                crystalDisplay[i].SetActive(true);
            }
        }
    }

    public void GameOver()
    {
        sceneIndex = 1;
        Invoke("ChangeScene", 3f);
    }

    private void Win()
    {
        sceneIndex = 2;
        Invoke("ChangeScene", 2f);
    }

    private int sceneIndex;
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
