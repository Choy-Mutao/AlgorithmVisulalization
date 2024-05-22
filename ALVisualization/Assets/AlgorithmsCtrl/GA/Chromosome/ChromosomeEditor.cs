using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LinearChromosomeCtrl))]
public class ChromosomeEditor : Editor
{
    private int selectedIndex = 0;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        serializedObject.Update();

        // Cast the target to your component type
        LinearChromosomeCtrl component = (LinearChromosomeCtrl)target;

        // Create a ComboBox control
        string[] options = component.GetOptions();
        selectedIndex = EditorGUILayout.Popup("PreChromosome Type:", selectedIndex, options);

        // Apply the selected option to your component
        component.SelectIndex(selectedIndex);

        //// If you need to perform some action when the selection changes, you can do it here
        //// For example, you could call a method on your component:
        //// component.HandleSelectionChange();

        //// Show the enum dropdown for selecting the option
        ////EditorGUILayout.PropertyField(serializedObject.FindProperty("selectedOption"));

        //// Show or hide parameters based on the selected option
        //switch (selectedIndex)
        //{
        //    case 0:
        //        EditorGUI.indentLevel++;
        //        EditorGUILayout.PropertyField(serializedObject.FindProperty("MinValue"), new GUIContent("Float Value"));
        //        EditorGUILayout.PropertyField(serializedObject.FindProperty("MaxValue"), new GUIContent("Float Value"));
        //        EditorGUILayout.PropertyField(serializedObject.FindProperty("Fraction"), new GUIContent("Int Value"));
        //        EditorGUI.indentLevel--;
        //        break;
        //    case 1:
        //        EditorGUI.indentLevel++;
        //        EditorGUILayout.PropertyField(serializedObject.FindProperty("MinValue"), new GUIContent("Int Value"));
        //        EditorGUILayout.PropertyField(serializedObject.FindProperty("MaxValue"), new GUIContent("Int Value"));
        //        EditorGUI.indentLevel--;
        //        break;
        //    default:
        //        break;
        //}

        //serializedObject.ApplyModifiedProperties();
    }
}
