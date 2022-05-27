using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Currency))]
public class CurrencyEditor : Editor
{
    int value = 100;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(15);

        value = EditorGUILayout.IntField("Value", value);

        GUILayout.Space(10);

        if (GUILayout.Button("Add Balance", GUILayout.Height(30)))
        {
            Currency.Add(value);
        }
        GUILayout.Space(5);

        if (GUILayout.Button("WithDraw Balance", GUILayout.Height(30)))
        {
            Currency.WithDraw(value);
        }
        GUILayout.Space(5);

        if (GUILayout.Button("Reset Balance", GUILayout.Height(30)))
        {
            Currency.ResetBalance();
        }
    }
}
