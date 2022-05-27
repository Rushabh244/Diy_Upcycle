using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FailScreen : MonoBehaviour
{
    [Header("UI REFERENCE")]
    [SerializeField] private Button RetryButton;
    [SerializeField] private Button HomeButton;

    public UnityScreenEvent UnityScreenEvent;

    #region OnEnable/Disable

    private void OnEnable()
    {
        UnityScreenEvent.OnScreenEnable?.Invoke();
    }
    private void OnDisable()
    {
        UnityScreenEvent.OnScreenDisable?.Invoke();
    }
    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        HomeButton.onClick.AddListener(OnHomeButtonPress);
        RetryButton.onClick.AddListener(OnRetryButtonPress);
    }

    #endregion

    #region Event Section

    public void OnHomeButtonPress()
    {
        UIAnimation.ButtonPressed(HomeButton, 0.1f, () =>
        {
            ScreenManager.Instance.HomeScreenObject.SetActive(true);
            ScreenManager.Instance.FailScreenObject.SetActive(false);
        });
    }

    public void OnRetryButtonPress()
    {
        UIAnimation.ButtonPressed(RetryButton, 0.1f, () =>
        {
            LevelHandler.ReloadLevelEvent();
            ScreenManager.Instance.GameplayScreenObject.SetActive(true);
            ScreenManager.Instance.FailScreenObject.SetActive(false);
            ScreenManager.Instance.isStart = true;
        });
    }

    #endregion

    #region Public Functions


    #endregion
}
