using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelStatusComponent : MonoBehaviour
{
    [Header("REFERENCE")]
    [SerializeField] private TextMeshProUGUI TMP_LevelStatus;

    #region OnEnable/Disable
    private void OnEnable()
    {
        LevelHandler.OnLevelStatusUpdate += LevelHandler_OnLevelStatusUpdate;
    }
    private void OnDisable()
    {
        LevelHandler.OnLevelStatusUpdate -= LevelHandler_OnLevelStatusUpdate;
    }
    #endregion

    private void LevelHandler_OnLevelStatusUpdate()
    {
        TMP_LevelStatus.text = GameDatabase.CurrentLevel.ToString();
    }
}
