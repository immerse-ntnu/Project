/*
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Attributes))]
public class AttributesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Create a property field for the maxSkillLevel variable
        SerializedProperty maxSkillLevelProp = serializedObject.FindProperty("maxSkillLevel");
        EditorGUILayout.PropertyField(maxSkillLevelProp);

        // Create property fields for the initialSkillLevels dictionary
        SerializedProperty initialSkillLevelsProp = serializedObject.FindProperty("initialSkillLevels");
        EditorGUILayout.PropertyField(initialSkillLevelsProp, true);

        // Create property fields for the skillLevels dictionary
        SerializedProperty skillLevelsProp = serializedObject.FindProperty("skillLevels");
        EditorGUILayout.PropertyField(skillLevelsProp, true);

        serializedObject.ApplyModifiedProperties();
    }
}
*/