using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public static LevelHandler Instance;

    public delegate void LevelHandlerEventHandler();

    public event LevelHandlerEventHandler LoopIncremented;

    public int LoopNr { get; private set; }

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
}
