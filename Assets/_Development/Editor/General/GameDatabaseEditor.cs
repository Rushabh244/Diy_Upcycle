using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameDatabase))]
public class GameDatabaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorUtility.SetDirty(target);

        serializedObject.UpdateIfRequiredOrScript();
        GameDatabase gameDatabase = (GameDatabase)target;

        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.IntField("CurrentLevel", GameDatabase.CurrentLevel);
        EditorGUILayout.IntField("LastBalance", GameDatabase.LastBalance);
        EditorGUILayout.IntField("CurrentBalance", GameDatabase.CurrentBalance);
        EditorGUI.EndDisabledGroup();
        serializedObject.ApplyModifiedProperties();


    }

}
