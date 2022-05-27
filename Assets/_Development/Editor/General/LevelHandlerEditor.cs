using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelHandler))]
public class LevelHandlerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //EditorGUI.BeginDisabledGroup(true);
        //EditorGUILayout.PropertyField(serializedObject.FindProperty("m_Script"));
        //EditorGUI.EndDisabledGroup();

        //GUILayout.Space(10);
        //GUILayout.Label("Example:-");
        //GUILayout.Label("LevelPath- Assets/Resources/LevelPrefab");
        //GUILayout.Label("LevelName- Level_1");

        //LevelHandler levelHandler = (LevelHandler)target;

        //if (levelHandler.OverrideLoadNewLevel.GetPersistentEventCount() > 0 ||
        //    levelHandler.OverrideOnReloadLevel.GetPersistentEventCount() > 0)
        //{
        //    GUIStyle gUIStyle1 = new GUIStyle();
        //    gUIStyle1.normal.textColor = Color.red;
        //    gUIStyle1.fontSize = 12;

        //    GUILayout.Label("Suggest to use GameDatabase.SetLevelNo() Method", gUIStyle1);
        //}

        //string[] args = new string[] { "m_Script" };
        //DrawPropertiesExcluding(serializedObject, args);

        //GUILayout.Space(15);

        GUIStyle gUIStyle = new GUIStyle();
        gUIStyle.fontStyle = FontStyle.Bold;
        gUIStyle.normal.textColor = new Color(0.7f, 0.7f, 0.7f);
        gUIStyle.fontSize = 10;
        gUIStyle.alignment = TextAnchor.MiddleCenter;
        gUIStyle.border = new RectOffset(2, 2, 2, 2);

        if (EditorApplication.isPlaying) gUIStyle.normal.textColor = Color.green;

        if (GUILayout.Button("Reset Level", GUILayout.Height(30)))
        {
            GameDatabase.SetLevelNo(1);
        }

        GUILayout.Space(5);
        GUILayout.Label("IN PLAYMODE", gUIStyle);
        GUILayout.Space(5);

        if (GUILayout.Button("Load New Level", GUILayout.Height(30)))
        {
            if (EditorApplication.isPlaying)
                LevelHandler.LoadNewLevelEvent();
        }
        GUILayout.Space(5);

        if (GUILayout.Button("Reload New Level", GUILayout.Height(30)))
        {
            if (EditorApplication.isPlaying)
                LevelHandler.ReloadLevelEvent();
        }
    }
}
