using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomizeTrackableEventHandler))]
public class TrakerEditorCtr : Editor{

    public override void OnInspectorGUI()
    {
        CustomizeTrackableEventHandler customizeTrackableEventHandler = (CustomizeTrackableEventHandler)target;
        if (GUILayout.Button("Build Object"))
        {
            Debug.Log("aaaa");
            customizeTrackableEventHandler.OnFind();
        }
    }
}
