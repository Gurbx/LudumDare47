using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUI : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Text text;

    public void ShowText(string displayText)
    {
        text.text = displayText;
        animator.SetBool("IsVisible", true);
    }

    public void HideText()
    {
        animator.SetBool("IsVisible", false);
    }
}
