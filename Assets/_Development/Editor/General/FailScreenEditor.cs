using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FailScreen))]
public class FailScreenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Script"));
        EditorGUI.EndDisabledGroup();

        FailScreen failScreen = (FailScreen)target;

        string[] args = new string[] { "UnityScreenEvent", "m_Script" };
        DrawPropertiesExcluding(serializedObject, args);

        GUIStyle gUIStyle = new GUIStyle();
        gUIStyle.fontStyle = FontStyle.Bold;
        gUIStyle.normal.textColor = new Color(0.7f,0.7f,0.7f);
        gUIStyle.fontSize = 12;
        gUIStyle.alignment = TextAnchor.MiddleCenter;
        gUIStyle.border = new RectOffset(2, 2, 2, 2);

        EditorGUILayout.Space(12);
        GUILayout.Label("---------------------------------EVENTS---------------------------------", gUIStyle);
        EditorGUILayout.Space(12);

        EditorGUILayout.PropertyField(serializedObject.FindProperty("UnityScreenEvent").FindPropertyRelative("eventType"));

        EditorGUILayout.Space(10);

        EditorGUILayout.PropertyField(serializedObject.FindProperty("UnityScreenEvent").FindPropertyRelative("OnScreenEnable"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("UnityScreenEvent").FindPropertyRelative("OnScreenDisable"));

        serializedObject.ApplyModifiedProperties();
    }
}
