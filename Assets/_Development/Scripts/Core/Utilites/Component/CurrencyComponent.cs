using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyComponent : MonoBehaviour
{
    [Header("UI REFERENCE")]
    [SerializeField] private TextMeshProUGUI TMP_Currency;

    #region OnEnable/Disable
    private void OnEnable()
    {
        Currency.RefreshCurrency += UpdateCurrency;
    }
    private void OnDisable()
    {
        Currency.RefreshCurrency -= UpdateCurrency;
    }
    #endregion

    #region Private Functions

    private void UpdateCurrency(int value, int lastValue)
    {
        GameObject _currencyObject = new GameObject();

        LeanTween.value(_currencyObject, (currency) =>
        {
            TMP_Currency.text = ((int)currency).ToString();
        },
        lastValue, value, 0.4f).setOnComplete(() =>
        {
            Destroy(_currencyObject);

            Currency.OnCurrencyUpdateEvent();
        });
    }

    #endregion
}
