using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(OctreeGizmoCtrl))]
public class OctreeEditor : Editor
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        var component = (OctreeGizmoCtrl)target;

        if (component == null) return;
        // Add a button to Inspector
        if (GUILayout.Button("Build"))
        {

        }

        if (GUILayout.Button("ImportJsonData"))
        {
        }

    }
}
