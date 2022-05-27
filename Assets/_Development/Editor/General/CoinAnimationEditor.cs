using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CoinAnimation))]
public class CoinAnimationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CoinAnimation coinAnimation = (CoinAnimation)target;

        GUILayout.Space(10);
        if (GUILayout.Button("Preview ( In PlayMode )", GUILayout.Height(30)) && EditorApplication.isPlaying)
        {
            coinAnimation.CoinAnimate(0.25f);
        }
        GUILayout.Space(10);
        base.OnInspectorGUI();
    }
}
