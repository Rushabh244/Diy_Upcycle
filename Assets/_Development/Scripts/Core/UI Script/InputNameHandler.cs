using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputNameHandler : MonoBehaviour
{
    private string userName = string.Empty;
    [SerializeField] private CanvasGroup m_CanvasGroup;

    [Header("UI REFERENCE")]
    [SerializeField] private TMP_InputField TMP_InputName;

    [Space(14)]
    [SerializeField] private GameObject Save;
    private Button Button_Save;

    [SerializeField] private GameObject Random;
    private Button Button_Random;

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        Button_Save = Save.GetComponent<Button>();
        Button_Save.onClick.AddListener(SaveUserName);

        Button_Random = Random.GetComponent<Button>();
        Button_Random.onClick.AddListener(SelectRandomName);

        TMP_InputName.onValueChanged.AddListener(OnNameChange);
    }
    private void Start()
    {
        TMP_InputName.text = PlayerPrefs.GetString("ID_USER_NAME", "Hello");
    }

    #endregion

    #region Private Functions

    private void SaveUserName()
    {
        UIAnimation.ClosePanelToClose(this.gameObject, m_CanvasGroup, 0.3f);
    }
    private void SelectRandomName()
    {
        TMP_InputName.text = "Random";
    }
    private void OnNameChange(string value)
    {
        PlayerPrefs.SetString("ID_USER_NAME", value);
    }

    #endregion
}
