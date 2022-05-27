using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    private int BlendTreeID;

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    #endregion

    #region Animation Functions

    public void SetBlendTreeValue(float value)
    {
        animator.SetFloat(BlendTreeID, value);
    }

    #endregion

    #region Private Functions

    private void AnimationIDs()
    {
        BlendTreeID = Animator.StringToHash("Blend");
    }

    #endregion

}
