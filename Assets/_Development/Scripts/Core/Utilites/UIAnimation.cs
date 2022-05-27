using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimation : MonoBehaviour
{
    #region Public Functions
    public static void ButtonPressed(Button button, float time, Action onCallback = null, bool isBounce = true)
    {
        button.interactable = false;
        GameObject targetObject = button.gameObject;
        Vector3 _originalScale = targetObject.transform.localScale;

        LeanTween.scale(targetObject, _originalScale * 0.85f, time).setOnComplete(() =>
        {
            if (isBounce)
            {
                LeanTween.scale(targetObject, _originalScale, time).setEase(LeanTweenType.easeOutBounce)
                .setOnComplete(() =>
                {
                    button.interactable = true;
                    onCallback?.Invoke();
                });
            }
            else
            {
                button.interactable = true;
                onCallback?.Invoke();
            }
        });

    }
    public static void ButtonPressBounceToPanelOpenToClose(Button button, GameObject targetObject, GameObject closePanel, CanvasGroup canvasGroup, float buttonTime, float panelTime, bool isPanelAlpha = true)
    {
        GameObject buttonObject = button.gameObject;

        Vector3 _originalButtonScale = buttonObject.transform.localScale;

        LeanTween.scale(buttonObject, _originalButtonScale * 0.75f, buttonTime).setOnComplete(() =>
        {
            LeanTween.scale(buttonObject, _originalButtonScale, buttonTime).setEase(LeanTweenType.easeOutBounce)
            .setOnComplete(() =>
            {
                closePanel.SetActive(false);

                Vector3 _originalScale = targetObject.transform.localScale;
                targetObject.transform.localScale = _originalScale * 0.7f;

                targetObject.SetActive(true);

                if (isPanelAlpha)
                {
                    canvasGroup.alpha = 0;
                    LeanTween.alphaCanvas(canvasGroup, 1, panelTime + 0.25f).setEase(LeanTweenType.easeOutSine);
                }
                LeanTween.scale(targetObject, _originalScale, panelTime).setEase(LeanTweenType.easeOutQuint);
            });
        });
    }
    public static void ButtonPressBounceToPanelOpen(Button button, GameObject targetObject, CanvasGroup canvasGroup, float buttonTime, float panelTime, bool isPanelAlpha = true)
    {
        GameObject buttonObject = button.gameObject;

        Vector3 _originalButtonScale = buttonObject.transform.localScale;

        LeanTween.scale(buttonObject, _originalButtonScale * 0.75f, buttonTime).setOnComplete(() =>
        {
            LeanTween.scale(buttonObject, _originalButtonScale, buttonTime).setEase(LeanTweenType.easeOutBounce)
            .setOnComplete(() =>
            {
                Vector3 _originalScale = targetObject.transform.localScale;
                targetObject.transform.localScale = _originalScale * 0.7f;

                targetObject.SetActive(true);

                if (isPanelAlpha)
                {
                    canvasGroup.alpha = 0;
                    LeanTween.alphaCanvas(canvasGroup, 1, panelTime + 0.25f).setEase(LeanTweenType.easeOutSine);
                }
                LeanTween.scale(targetObject, _originalScale, panelTime).setEase(LeanTweenType.easeOutQuint);
            });
        });
    }
    public static void ButtonPressToPanelOpen(Button button, GameObject targetObject, GameObject closePanel, CanvasGroup canvasGroup, bool isPanelAlpha, float buttonTime, float panelTime)
    {
        GameObject buttonObject = button.gameObject;

        Vector3 _originalButtonScale = buttonObject.transform.localScale;

        LeanTween.scale(buttonObject, _originalButtonScale * 0.6f, buttonTime).setEase(LeanTweenType.easeInQuint).setOnComplete(() =>
        {
            closePanel.SetActive(false);
            buttonObject.transform.localScale = _originalButtonScale;

            Vector3 _originalScale = targetObject.transform.localScale;
            targetObject.transform.localScale = _originalScale * 0.7f;

            targetObject.SetActive(true);

            if (isPanelAlpha)
            {
                canvasGroup.alpha = 0;
                LeanTween.alphaCanvas(canvasGroup, 1, panelTime + 0.25f).setEase(LeanTweenType.easeOutSine);
            }
            LeanTween.scale(targetObject, _originalScale, panelTime).setEase(LeanTweenType.easeOutQuint);
        });
    }
    public static void OpenPanel(GameObject targetObject, CanvasGroup canvasGroup, bool isAlpha, float time)
    {
        Vector3 _originalScale = targetObject.transform.localScale;
        targetObject.transform.localScale = _originalScale * 0.7f;

        targetObject.SetActive(true);

        if (isAlpha)
        {
            canvasGroup.alpha = 0;
            LeanTween.alphaCanvas(canvasGroup, 1, time + 0.25f).setEase(LeanTweenType.easeOutSine);
        }
        LeanTween.scale(targetObject, _originalScale, time).setEase(LeanTweenType.easeOutQuint);
    }

    public static void ClosePanelToClose(GameObject targetObject, CanvasGroup canvasGroup, float time)
    {
        Vector3 _originalScale = targetObject.transform.localScale;

        canvasGroup.alpha = 1;
        LeanTween.alphaCanvas(canvasGroup, 0, time - 0.05f).setEase(LeanTweenType.easeInSine);

        LeanTween.scale(targetObject, _originalScale * 0.7f, time).setEase(LeanTweenType.easeInQuint)
            .setOnComplete(() =>
            {
                targetObject.SetActive(false);
                targetObject.transform.localScale = _originalScale;
                canvasGroup.alpha = 1;
            });
    }
    #endregion 
}
