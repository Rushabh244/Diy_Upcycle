using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HomeScreen : MonoBehaviour
{
    [Header("UI REFERENCE")]
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button SettingButton;

    [Header("OBJECT REFERENCE")]
    [SerializeField] private GameObject ScreenContent;
    [SerializeField] private GameObject SettingPanel;

    [Space(14)]
    [SerializeField] private CanvasGroup m_CanvasGroup;
    [SerializeField] private CanvasGroup SettingPanel_CanvasGroup;
    [SerializeField] private CanvasGroup InputPanel_CanvasGroup;

    public UnityGameEvent UnityGameEvent;

    #region OnEnable/Disable

    private void OnEnable()
    {
        UnityGameEvent.OnScreenEnable?.Invoke();
    }
    private void OnDisable()
    {
        UnityGameEvent.OnScreenDisable?.Invoke();
    }

    #endregion

    #region MonoBehaviour CallBacks

    private void Awake()
    {
        //PlayButton.onClick.AddListener(OnPlayButtonPress);
        SettingButton.onClick.AddListener(OnSettingButtonPress);
    }
    private void Start()
    {
        TapToPayAnimationLoop(0.95f, 0.35f);
    }

    #endregion

    #region Event Section

    public void OnPlayButtonPress()
    {
        StartCoroutine(OpenGameplayScreen());
        ScreenManager.Instance.isStart = true;

    }

    public void OnSettingButtonPress()
    {
        UIAnimation.ButtonPressBounceToPanelOpen(SettingButton, SettingPanel, SettingPanel_CanvasGroup, 0.1f, 0.4f);
    }

    #endregion

    #region Public Functions

    #endregion

    #region Private Functions

    private IEnumerator OpenGameplayScreen()
    {
        ScreenManager.Instance.LoadingScreenObject.SetActive(true);
        m_CanvasGroup.alpha = 0;
        m_CanvasGroup.interactable = false;

        yield return new WaitForSeconds(1.25f);

        CanvasGroup canvasGroup = ScreenManager.Instance.LoadingScreen.GetComponent<CanvasGroup>();

        LeanTween.value(new GameObject(), (value) =>
        {
            canvasGroup.alpha = value;

        }, 1, 0, 0.25f).setOnComplete(() =>
        {
            ScreenManager.Instance.LoadingScreenObject.SetActive(false);
            ScreenManager.Instance.GameplayScreenObject.SetActive(true);

            UnityGameEvent.OnGameStart?.Invoke();

            canvasGroup.alpha = 1;
            m_CanvasGroup.alpha = 1;
            m_CanvasGroup.interactable = true;
            ScreenManager.Instance.HomeScreenObject.SetActive(false);
        });
    }
    private void TapToPayAnimationLoop(float scale, float time)
    {
        Vector3 _originalScale = PlayButton.gameObject.transform.localScale;
        LeanTween.scale(PlayButton.gameObject, _originalScale * scale, time).setLoopPingPong();
    }

    #endregion

}
