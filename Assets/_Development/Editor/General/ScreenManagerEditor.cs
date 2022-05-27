using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScreenManager))]
public class ScreenManagerEditor : Editor
{
    bool isEdit = false;
    string buttonName = "Enable Edit";
    public override void OnInspectorGUI()
    {
        EditorUtility.SetDirty(target);

        ScreenManager screenManager = (ScreenManager)target;

        GUIStyle gUIStyle = new GUIStyle();
        gUIStyle.fontStyle = FontStyle.Bold;
        gUIStyle.normal.textColor = new Color(0.7f, 0.7f, 0.7f);
        gUIStyle.fontSize = 12;
        gUIStyle.alignment = TextAnchor.MiddleCenter;
        gUIStyle.border = new RectOffset(2, 2, 2, 2);

        if (screenManager.HomeScreenObject.activeInHierarchy ||
            screenManager.GameplayScreenObject.activeInHierarchy ||
            screenManager.VictoryScreenObject.activeInHierarchy ||
            screenManager.FailScreenObject.activeInHierarchy)
        {
            gUIStyle.normal.textColor = Color.green;
        }

        serializedObject.Update();

        EditorGUILayout.Space(15);

        if (GUILayout.Button(buttonName))
        {
            if(buttonName == "Enable Edit")
            {
                isEdit = true;
                buttonName = "Disable Edit";
            }
            else if(buttonName == "Disable Edit")
            {
                isEdit = false;
                buttonName = "Enable Edit";
            }
        }
        EditorGUILayout.Space(15);

        serializedObject.ApplyModifiedProperties();

        if (isEdit)
        {
            base.OnInspectorGUI();
        }
        else
        {
            EditorGUI.BeginDisabledGroup(true);
            base.OnInspectorGUI();
            EditorGUI.EndDisabledGroup();
        }

        EditorGUILayout.Space(12);
        GUILayout.Label("ACTIVE SCREEN STATUS", gUIStyle);
        EditorGUILayout.Space(12);

        if (screenManager.HomeScreenObject.activeInHierarchy)
            GUILayout.Button("Active Home Screen", GUILayout.Height(30));
        if (screenManager.GameplayScreenObject.activeInHierarchy)
            GUILayout.Button("Active Gameplay Screen", GUILayout.Height(30));
        if (screenManager.VictoryScreenObject.activeInHierarchy)
            GUILayout.Button("Active Victory Screen", GUILayout.Height(30));
        if (screenManager.FailScreenObject.activeInHierarchy)
            GUILayout.Button("Active Fail Screen", GUILayout.Height(30));
    }
}
