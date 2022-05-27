using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [Space(14)]
    [SerializeField] private bool PlayTheme = true;

    [Header("AUDIOSOURCE REFERENCE")]
    [SerializeField] private AudioSource MainTheme_AudioSource;
    [SerializeField] private AudioSource SFX_AudioSource;

    [Header("AUDIOCLIP REFERENCE")]
    [SerializeField] private AudioClip MainThemeClip;

    [Space(14)]
    [SerializeField] private AudioClip AudienceCheeringClip;
    [SerializeField] private AudioClip LevelVictoryClip;
    [SerializeField] private AudioClip LevelFailClip;
    [SerializeField] private AudioClip CoinClip;
    [SerializeField] private AudioClip ButtonClickClip;

    public static AudioController Instance;

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        Instance = this;
        if (PlayTheme) PlayMainTheme();
    }
    private void Start()
    {
    }

    #endregion

    #region Sound Section
    public void PlayMainTheme()
    {
        MainTheme_AudioSource.clip = MainThemeClip;
        MainTheme_AudioSource.Play();
    }
    public void PlayAudienceCheering()
    {
        AudioPlayer(AudienceCheeringClip);
    }
    public void PlayButtonSound()
    {
        AudioPlayer(ButtonClickClip);
    }
    public void PlayCoinSound()
    {
        AudioPlayer(CoinClip);
    }
    public void PlayLevelVictorySound()
    {
        AudioPlayer(LevelVictoryClip);
    }
    public void PlayLevelFailSound()
    {
        AudioPlayer(LevelFailClip);
    }
    #endregion

    #region Private Functions

    private void AudioPlayer(AudioClip audioClip)
    {
        if (GameDatabase.isAudio)
        {
            SFX_AudioSource.PlayOneShot(audioClip);
        }
    }

    #endregion
}
