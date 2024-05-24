using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PopulationCtrl))]
public class PupulationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var component = (PopulationCtrl)target;

        if (component == null) return;
        // Add a button to Inspector
        if(GUILayout.Button("CreateInitialGeneration"))
        {
            component.CreateInitialGeneration();
        }

        if(GUILayout.Button("CreateNewGeneration"))
        {
            component.CreateNewGeneration();
        }

        if(GUILayout.Button("EndCurrentGeneration"))
        {
            component.EndCurrentGeneration();
        }
    }
}
