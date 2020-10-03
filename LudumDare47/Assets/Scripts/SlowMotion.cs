using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    private float fixedDeltaTime;
    private static float fadeInTimer;
    private static float fadeOutTimer;
    private static float fadeInDuration;
    private static float fadeOutDuration;
    private static float slowAmmount;

    private void Awake()
    {
        fixedDeltaTime = Time.fixedDeltaTime;
    }

    public static void SlowTime(float amount, float fadeInTime, float fadeOutTime)
    {
        fadeInDuration = fadeInTime;
        fadeOutDuration = fadeOutTime;
        fadeInTimer = 0;
        fadeOutTimer = 0;
        slowAmmount = amount;
    }

    void Update()
    {

        if (fadeInTimer <= fadeInDuration)
        {
            fadeInTimer += Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Lerp(Time.timeScale, slowAmmount, fadeInTimer / fadeInDuration);
        }
        else if (fadeOutTimer <= fadeOutDuration)
        {
            fadeOutTimer += Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, fadeOutTimer / fadeOutDuration);
        }
        else
        {
            Time.timeScale = 1f;
        }

        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }
}
