using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public static LevelHandler Instance;

    public List<GameObject> crystalDisplay;

    public delegate void LevelHandlerEventHandler();

    public event LevelHandlerEventHandler LoopIncremented;
    public event LevelHandlerEventHandler CrystalCollected;

    public int LoopNr { get; private set; }
    public int Crystals { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            GameObject.Destroy(this);
            return;
        }

        Instance = this;
        LoopNr = 0;
    }

    public void IncrementLoop()
    {
        LoopNr++;
        if (LoopIncremented != null)
        {
            LoopIncremented.Invoke();
        }
    }

    public void IncrementCrystals()
    {
        Crystals++;
        if (Crystals >= 5)
        {
            Win();
        }
        else
        {
            if (CrystalCollected != null)
            {
                CrystalCollected.Invoke();
            }
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

    }

    private void Win()
    {

    }
}
