using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PopulationCtrl))]
public class PupulationEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        // Add a button to Inspector
        if(GUILayout.Button("CreateInitialGeneration"))
        {

        }

        if(GUILayout.Button("CreateNewGeneration"))
        {

        }

        if(GUILayout.Button("EndCurrentGeneration"))
        {

        }
    }
}
