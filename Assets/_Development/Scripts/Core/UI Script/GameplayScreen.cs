using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameplayScreen : MonoBehaviour
{
    [Header("UI REFERENCE")]
    [SerializeField] private Button ReloadButton;

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
        ReloadButton.onClick.AddListener(OnReloadButtonPress);
    }

    #endregion

    #region Event Section

    public void OnReloadButtonPress()
    {
        UIAnimation.ButtonPressed(ReloadButton, 0.1f, () =>
        {
            LevelHandler.ReloadLevelEvent();
        });
    }

    #endregion
}
