using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingHandler : MonoBehaviour
{
    [SerializeField] private CanvasGroup m_CanvasGroup;
    [Header("AUDIO REFERENC")]

    [SerializeField] private GameObject Audio;
    [SerializeField] private Sprite Audio_Enable;
    [SerializeField] private Sprite Audio_Disable;
    private Button AudioButton;
    private Image Image_Audio;
    private bool isSound = true;

    [Header("HAPTIC REFERENC")]
    [SerializeField] private GameObject Haptic;
    [SerializeField] private Sprite Haptic_Enable;
    [SerializeField] private Sprite Haptic_Disable;
    private Button HapticButton;
    private Image Image_Haptic;
    private bool isHaptic = true;

    #region OnEnable/Disable

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        // Get Audio Component
        AudioButton = Audio.GetComponent<Button>();
        Image_Audio = Audio.GetComponent<Image>();
        AudioButton.onClick.AddListener(AudioToggle);

        // Get Haptic Component
        HapticButton = Haptic.GetComponent<Button>();
        Image_Haptic = Haptic.GetComponent<Image>();
        HapticButton.onClick.AddListener(HapticToggle);
    }
    private void Start()
    {
        UpdateStatus();
    }

    #endregion

    #region Audio Section
    private void AudioToggle()
    {
        UIAnimation.ButtonPressed(AudioButton, 0.1f);

        isSound = !isSound;

        GameDatabase.SetAudio(isSound);

        AudioUpdateSprite();
    }
    private void AudioUpdateSprite()
    {
        if (isSound) Image_Audio.sprite = Audio_Enable;
        else Image_Audio.sprite = Audio_Disable;
    }
    #endregion

    #region Haptic Section
    private void HapticToggle()
    {
        UIAnimation.ButtonPressed(HapticButton, 0.1f);

        isHaptic = !isHaptic;

        GameDatabase.SetHaptic(isHaptic);

        HapticUpdateSprite();
    }
    private void HapticUpdateSprite()
    {
        if (isHaptic) Image_Haptic.sprite = Haptic_Enable;
        else Image_Haptic.sprite = Haptic_Disable;
    }
    #endregion
    
    #region Public Functions
    public void ClosePanel()
    {
        UIAnimation.ClosePanelToClose(this.gameObject, m_CanvasGroup, 0.3f);
    }

    #endregion

    #region Private Functions

    private void UpdateStatus()
    {
        isSound = GameDatabase.isAudio;
        isHaptic = GameDatabase.isHaptic;

        AudioUpdateSprite();
        HapticUpdateSprite();
    }

    #endregion

}
