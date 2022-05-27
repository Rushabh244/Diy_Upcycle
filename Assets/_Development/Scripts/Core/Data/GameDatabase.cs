using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDatabase : MonoBehaviour
{
    public static int CurrentLevel { get { return PlayerPrefs.GetInt("ID_LEVEL_CURRENT", 1); } }
    public static bool isAudio { get { return bool.Parse(PlayerPrefs.GetString("ID_AUDIO_STATUS", "true")); } }
    public static bool isHaptic { get { return bool.Parse(PlayerPrefs.GetString("ID_HAPTIC_STATUS", "true")); } }

    public static int LastBalance { get { return PlayerPrefs.GetInt("ID_CURRENCY_LAST", 0); } }
    public static int CurrentBalance { get { return PlayerPrefs.GetInt("ID_CURRENCY_CURRENT", 0); } }


    #region SettingPanel Section
    public static void SetAudio(bool isEnable)
    {
        PlayerPrefs.SetString("ID_AUDIO_STATUS", isEnable.ToString());
    }

    public static void SetHaptic(bool isEnable)
    {
        PlayerPrefs.SetString("ID_HAPTIC_STATUS", isEnable.ToString());
    }
    #endregion

    #region Level Section

    public static void SetLevelNo(int levelNo)
    {
        PlayerPrefs.SetInt("ID_LEVEL_CURRENT", levelNo);
    }

    #endregion

    #region Currency Balance Section

    public static void SetLastBalance(int value)
    {
        PlayerPrefs.SetInt("ID_CURRENCY_LAST", value);
    }

    public static void SetCurrentBalance(int value)
    {
        PlayerPrefs.SetInt("ID_CURRENCY_CURRENT", value);
    }

    #endregion
}
