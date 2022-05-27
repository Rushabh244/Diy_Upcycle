using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CoinAnimation : MonoBehaviour
{
    [Space(7)]
    [SerializeField] private bool isRandomPosition = true;
    [Header("OBJECT REFERENCE")]
    [SerializeField] private RectTransform EndPosition;
    [SerializeField] private GameObject CoinPrefab;

    private Vector2 startPosition;
    private Vector2 endPosition;

    private int coinCount = 11;
    private Canvas canvas;

    [Space(10)]
    public UnityEvent OnCoinAnimationComplete;
    public static event Action OnCoinAnimationCompleteEvent;

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        if (canvas == null) canvas = FindObjectOfType<Canvas>();
    }
    private void Start()
    {
        SetDefaultPosition();
    }
    #endregion

    #region Event Section

    public void CoinAnimate(float duration)
    {
        if (isRandomPosition) StartCoroutine(AnimateAnimationWithRandom(duration));
        else StartCoroutine(AnimateAnimation(duration));
    }
    public void CoinAnimationCompleteEvent()
    {
        OnCoinAnimationComplete?.Invoke();
        OnCoinAnimationCompleteEvent?.Invoke();
    }

    #endregion

    #region Private Function

    private void SetDefaultPosition()
    {
        RectTransform rectTransform = CoinPrefab.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);

        // Set StartPosition
        int x1 = 0;
        int y1 = (int)(-(Screen.height * 0.5f) + 300);

        startPosition = new Vector2(x1, y1);

        // Set EndPosition
        int x2 = (int)((Screen.width * 0.5f) - 250);
        int y2 = (int)(Screen.height * 0.5f) - (int)(rectTransform.rect.height * 0.5f);

        endPosition = canvas.transform.InverseTransformPoint(EndPosition.transform.position);
    }

    private IEnumerator AnimateAnimation(float duration)
    {
        int value = 0;

        for (int i = 0; i < coinCount; i++)
        {
            GameObject coinObject = Instantiate(CoinPrefab, canvas.transform);

            RectTransform rectTransform = coinObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = startPosition;

            Vector2 originalScale = coinObject.transform.localScale;
            coinObject.transform.localScale = Vector2.zero;

            LeanTween.scale(coinObject, originalScale * 1.1f, 0.2f).setOnComplete(() =>
            {
                LeanTween.move(rectTransform, endPosition, duration).setOnComplete(() =>
                {
                    if (value == coinCount - 1) CoinAnimationCompleteEvent();
                    Destroy(coinObject, 0.05f);
                    value++;
                });
            });

            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator AnimateAnimationWithRandom(float duration)
    {
        int value = 0;

        for (int i = 0; i < coinCount; i++)
        {
            GameObject coinObject = Instantiate(CoinPrefab, canvas.transform);

            RectTransform rectTransform = coinObject.GetComponent<RectTransform>();

            // Set Random Position
            Vector2 randomPosition = new Vector2(
                startPosition.x + UnityEngine.Random.Range(-150f, 150f),
                startPosition.y + UnityEngine.Random.Range(-150f, 150f));

            rectTransform.anchoredPosition = randomPosition;

            Vector2 originalScale = coinObject.transform.localScale;
            coinObject.transform.localScale = Vector2.zero;

            LeanTween.scale(coinObject, originalScale * 1.1f, 0.2f).setOnComplete(() =>
            {
                LeanTween.move(rectTransform, endPosition, duration + UnityEngine.Random.Range(-0.1f, 0.05f)).setDelay(0.5f).setOnComplete(() =>
                 {
                     if (value == coinCount - 1) CoinAnimationCompleteEvent();
                     Destroy(coinObject, 0.05f);
                     value++;
                 });
            });

            yield return new WaitForEndOfFrame();
        }
    }
    #endregion
}
