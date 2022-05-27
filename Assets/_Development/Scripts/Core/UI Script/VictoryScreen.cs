using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    [Header("UI REFERENCE")]
    [SerializeField] private Button HomeButton;
    [SerializeField] private Button NextButton;

    public GameObject shop;
    public GameObject Nackles;

    [Header("OBJECT REFERENCE")]

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
        // Set Button Listener internally (To Prevent Mistacks)
        HomeButton.onClick.AddListener(OnHomeButtonPress);
        NextButton.onClick.AddListener(OnNextButtonPress);
    }

    #endregion

    #region Event Section

    public void OnNextButtonPress()
    {
        UIAnimation.ButtonPressed(NextButton, 0.1f, () =>
        {
            ScreenManager.Instance.GameplayScreenObject.SetActive(true);

            LevelHandler.LoadNewLevelEvent();
            ScreenManager.Instance.VictoryScreenObject.SetActive(false);
        });
    }
    public void OnHomeButtonPress()
    {
        UIAnimation.ButtonPressed(HomeButton, 0.1f, () =>
        {
            ScreenManager.Instance.HomeScreenObject.SetActive(true);

            LevelHandler.LoadNewLevelEvent();

            ScreenManager.Instance.VictoryScreenObject.SetActive(false);
        });
    }

    #endregion
}
