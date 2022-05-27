using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [Header("UI REFERENCE")]
    [SerializeField] private GameObject LoadingObject;

    #region OnEnable/Disable

    private void OnEnable()
    {
        LoadingObject.transform.localScale = Vector3.one * 0.75f;
        LeanTween.scale(LoadingObject, Vector3.one, 0.35f).setEase(LeanTweenType.easeInOutBounce);
    }

    #endregion
}
