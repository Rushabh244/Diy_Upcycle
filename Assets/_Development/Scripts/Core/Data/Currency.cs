using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public static event Action OnCurrencyUpdate;
    public static event Action<int, int> RefreshCurrency;

    #region OnEnable/Disable



    #endregion

    #region MonoBehaviour Callbacks

    private void Start()
    {
        RefreshCurrencyEvent();
    }

    #endregion

    #region Event Function
    public static void OnCurrencyUpdateEvent() => OnCurrencyUpdate?.Invoke();
    public static void RefreshCurrencyEvent() => RefreshCurrency?.Invoke(GameDatabase.CurrentBalance, GameDatabase.LastBalance);

    #endregion

    #region Utility Function
    public static void Add(int value)
    {
        int _currentBalance = GameDatabase.CurrentBalance + value;

        GameDatabase.SetLastBalance(GameDatabase.CurrentBalance);
        GameDatabase.SetCurrentBalance(_currentBalance);

        RefreshCurrencyEvent();

    }
    public static void WithDraw(int value)
    {
        int _currentBalance = GameDatabase.CurrentBalance - value;

        GameDatabase.SetLastBalance(GameDatabase.CurrentBalance);
        GameDatabase.SetCurrentBalance(_currentBalance);

        RefreshCurrencyEvent();
    }
    public static void ResetBalance()
    {
        GameDatabase.SetLastBalance(0);
        GameDatabase.SetCurrentBalance(0);

        RefreshCurrencyEvent();
    }
    #endregion
}
