using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopItem : MonoBehaviour
{
    [SerializeField] private int activeDuringLoop;

    void Start()
    {
        LevelHandler.Instance.LoopIncremented += OnLoopIncremented;
        HandleActivation();
    }

    private void OnLoopIncremented()
    {
        HandleActivation();
    }

    private void HandleActivation()
    {
        if (gameObject == null)
        {
            return;
        }
        if (activeDuringLoop == LevelHandler.Instance.LoopNr)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        LevelHandler.Instance.LoopIncremented -= OnLoopIncremented;
    }
}
