using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("SETTINGS")]
    [Range(0.1f, 10f)]
    public float Speed = 4F;
    [Range(0.1f, 10f)]
    public float LefRightSpeed = 2.5F;
    [Range(0.5f, 10f)]
    public float Clamp = 3f;

    private bool isTouch = true;
    private float horizontalAxis = 0;

    private float Magnitude = 25;
    private Vector2 startPosition;
    private Vector2 endPosition;

    private GameObject smoothMovement;

    [Header("SCRIPT REFERENCE")]
    [SerializeField] private PlayerAnimation m_PlayerAnimation;




    #region MonoBehaviour Callbacks

    private void Awake()
    {
        this.TryGetComponent<PlayerAnimation>(out m_PlayerAnimation);

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
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            endPosition = startPosition;
        }

        if (Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
            float distance = Vector2.Distance(startPosition, endPosition);

            if (distance > Magnitude)
            {
                if (startPosition.x < endPosition.x)
                {
                    RightMove();
                }
                if (startPosition.x > endPosition.x)
                {
                    LeftMove();
                }

                startPosition = endPosition;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            startPosition = endPosition;
            ForwardLook();
        }

        // Update Movement
        Vector3 currentPosition = transform.position;

        currentPosition.z += Speed * Time.deltaTime;
        currentPosition.x += horizontalAxis * LefRightSpeed * Time.deltaTime;

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

        if (m_PlayerAnimation) SmoothBlendLeft();
    }
    private void ForwardLook()
    {
        LeanTween.value(smoothMovement, (value) =>
        {
            horizontalAxis = value;
        }
        , horizontalAxis, 0, 0.125f).setEase(LeanTweenType.easeOutSine);

        if (m_PlayerAnimation) SmoothBlendLookForward();
    }
    private void RightMove()
    {
        LeanTween.value(smoothMovement, (value) =>
        {
            horizontalAxis = value;
        }
        , horizontalAxis, 1, 0.125f).setEase(LeanTweenType.easeOutSine);

        if (m_PlayerAnimation) SmoothBlendRight();
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
            m_PlayerAnimation.SetBlendTreeValue(value);
        }
        , horizontalAxis, 0.0f, blendSmoothValue).setEase(LeanTweenType.easeOutSine);
    }

    private void SmoothBlendLookForward()
    {
        LeanTween.value(smoothMovement, (value) =>
        {
            m_PlayerAnimation.SetBlendTreeValue(value);
        }
        , horizontalAxis, 0.5f, blendSmoothValue).setEase(LeanTweenType.easeOutSine);
    }

    private void SmoothBlendRight()
    {
        LeanTween.value(smoothMovement, (value) =>
        {
            m_PlayerAnimation.SetBlendTreeValue(value);
        }
        , horizontalAxis, 1.0f, blendSmoothValue).setEase(LeanTweenType.easeOutSine);
    }

    #endregion

    #endregion

    #region Public Functions

    public void Stop()
    {
        isTouch = false;
    }

    #endregion
}
