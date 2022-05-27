using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{

    [Header("SETTINGS")]
    [Range(0.1f, 10f)]
    public float Speed = 4F;
    [Range(0.5f, 10f)]
    public float Clamp = 3f;

    private bool isTouch = true;

    private float LefRightSpeed = 2.5F;
    private float desicionTime = 2f;
    private float horizontalAxis = 0;

    private int forwardAttempt = 0;

    private GameObject smoothMovement;

    [Header("SCRIPT REFERENCE")]
    [SerializeField] private BotAnimation m_BotAnimation;

    private const int MAX_ATTEMPT_FORWARD = 2;



    #region MonoBehaviour Callbacks

    private void Awake()
    {
        this.TryGetComponent<BotAnimation>(out m_BotAnimation);

        smoothMovement = new GameObject();
        smoothMovement.name = "smoothMovement";
    }

    private void Update()
    {
        if (isTouch) TouchController();
    }

    #endregion

    #region Touch Section
    private void TouchController()
    {
        if (desicionTime > 0)
        {
            desicionTime -= Time.deltaTime;
        }
        else
        {
            desicionTime = UnityEngine.Random.Range(0.4f, 1.75f);  // Random Desicion Time

            LefRightSpeed = UnityEngine.Random.Range(0.25f, 1.5f); // Random LeftRight Speed

            int randomDirection = UnityEngine.Random.Range(0, 3);  // Random Direction

            // For Not Constant Move Forward
            if(forwardAttempt > MAX_ATTEMPT_FORWARD)
            {
                int randomNewDirection = UnityEngine.Random.Range(0, 2);

                if (randomNewDirection == 0) randomDirection = 0;
                else randomDirection = 2;

                forwardAttempt = 0;
            }           

            if (randomDirection == 0)
            {
                LeftMove();
            }
            else if (randomDirection == 1)
            {
                ForwardMove();
                forwardAttempt++;
            }
            else if (randomDirection == 2)
            {
                RightMove();
            }
        }

        // Update Movement
        Vector3 currentPosition = transform.position;

        currentPosition.z += Speed * Time.deltaTime;
        currentPosition.x += horizontalAxis * LefRightSpeed * Time.deltaTime;

        if(currentPosition.x >= (Clamp - 0.05f) || currentPosition.x <= -(Clamp - 0.05f))
        {
            ForwardMove();
        }

        currentPosition.x = Mathf.Clamp(currentPosition.x, -Clamp, Clamp);
        transform.position = currentPosition;
    }

    #region Smooth Move

    private void LeftMove()
    {
        LeanTween.value(smoothMovement, (value) =>
        {
            horizontalAxis = value;
        }
        , horizontalAxis, -1, 0.125f).setEase(LeanTweenType.easeOutSine);

        if (m_BotAnimation) SmoothBlendLeft();
    }
    private void ForwardMove()
    {
        LeanTween.value(smoothMovement, (value) =>
        {
            horizontalAxis = value;
        }
        , horizontalAxis, 0, 0.125f).setEase(LeanTweenType.easeOutSine);

        if (m_BotAnimation) SmoothBlendLookForward();
    }
    private void RightMove()
    {
        LeanTween.value(smoothMovement, (value) =>
        {
            horizontalAxis = value;
        }
        , horizontalAxis, 1, 0.125f).setEase(LeanTweenType.easeOutSine);

        if (m_BotAnimation) SmoothBlendRight();
    }

    #endregion

    #region Smooth Blend Shape
    //----------------------------------//

    // Notice -> Blend value -- For  || LeftLook = 0.0f | LookForwad = 0.5f | RightLook = 1.0f

    //----------------------------------//

    private float blendSmoothValue = 0.125f;

    private void SmoothBlendLeft()
    {
        LeanTween.value(smoothMovement, (value) =>
        {
            m_BotAnimation.SetBlendTreeValue(value);
        }
        , horizontalAxis, 0.0f, blendSmoothValue).setEase(LeanTweenType.easeOutSine);
    }

    private void SmoothBlendLookForward()
    {
        LeanTween.value(smoothMovement, (value) =>
        {
            m_BotAnimation.SetBlendTreeValue(value);
        }
        , horizontalAxis, 0.5f, blendSmoothValue).setEase(LeanTweenType.easeOutSine);
    }

    private void SmoothBlendRight()
    {
        LeanTween.value(smoothMovement, (value) =>
        {
            m_BotAnimation.SetBlendTreeValue(value);
        }
        , horizontalAxis, 1.0f, blendSmoothValue).setEase(LeanTweenType.easeOutSine);
    }

    #endregion

    #endregion
}
