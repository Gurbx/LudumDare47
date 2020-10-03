using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform cameraTransform;

    private Vector3 mousePosition;
    private Vector3 targetPos;

    private static float shakeAmount = 0.7f;
    private static float shakeDuration;
    private static float shakeDecrease = 1f;

    private Vector3 orgCamPos;

    void Update()
    {
        HandleCameraTarget();
        if (shakeDuration > 0)
        {
            orgCamPos = cameraTransform.localPosition;
            cameraTransform.localPosition = orgCamPos + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeDuration = 0;
        }
    }

    private void HandleCameraTarget()
    {
        if (playerTransform == null)
        {
            return;
        }

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDirection = mousePosition - targetTransform.position;

        targetPos = targetTransform.position;

        targetPos.x += targetTransform.position.x + mouseDirection.x - playerTransform.position.x;
        targetPos.y += targetTransform.position.y + mouseDirection.y - playerTransform.position.y;
        targetPos.z = -10;

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseOffset = mousePosition - targetTransform.position;

        mouseOffset = new Vector2(mousePosition.x, mousePosition.y) - new Vector2(playerTransform.position.x, playerTransform.position.y);

        mouseOffset *= 0.3f;
        mouseOffset.x = Mathf.Clamp(mouseOffset.x, -6, 6);
        mouseOffset.y = Mathf.Clamp(mouseOffset.y, -6, 6);
        mouseOffset.z = -10;

        targetTransform.localPosition = Vector3.Lerp(targetTransform.localPosition, mouseOffset, 0.3f);

        Camera.main.transform.position = targetTransform.position;
    }

    public static void ScreenShake(float amount, float duration, float decrease)
    {
        if (shakeDuration > 0 && shakeAmount > amount)
        {
            return;
        }
        shakeAmount = amount;
        shakeDuration = duration;
        shakeDecrease = decrease;
    }
}
