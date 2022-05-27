using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(HomeScreen))]
public class HomeScreenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Script"));
        EditorGUI.EndDisabledGroup();

        HomeScreen homeScreen = (HomeScreen)target;

        string[] args = new string[] { "UnityGameEvent", "m_Script" };
        DrawPropertiesExcluding(serializedObject, args);

        GUIStyle gUIStyle = new GUIStyle();
        gUIStyle.fontStyle = FontStyle.Bold;
        gUIStyle.normal.textColor = new Color(0.7f, 0.7f, 0.7f);
        gUIStyle.fontSize = 12;
        gUIStyle.alignment = TextAnchor.MiddleCenter;
        gUIStyle.border = new RectOffset(2, 2, 2, 2);

        EditorGUILayout.Space(12);
        GUILayout.Label("---------------------------------EVENTS---------------------------------", gUIStyle);
        EditorGUILayout.Space(12);

        EditorGUILayout.PropertyField(serializedObject.FindProperty("UnityGameEvent").FindPropertyRelative("eventType"));

        EditorGUILayout.Space(10);

        switch (homeScreen.UnityGameEvent.eventType)
        {
            case UnityGameEvent.EventType.ScreenEvent:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("UnityGameEvent").FindPropertyRelative("OnScreenEnable"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("UnityGameEvent").FindPropertyRelative("OnScreenDisable"));
                break;

            case UnityGameEvent.EventType.GameEvent:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("UnityGameEvent").FindPropertyRelative("OnGameStart"));
                break;
            default:
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
