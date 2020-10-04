using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinText : MonoBehaviour
{
    [SerializeField] private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "You Are Victorious!\nTime Left: " + LevelHandler.Instance.TimeLeft;
    }
}
