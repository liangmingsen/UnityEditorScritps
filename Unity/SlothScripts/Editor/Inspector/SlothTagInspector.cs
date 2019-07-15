using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects, CustomEditor(typeof(SlothTagMono))]
public class SlothTagInspector : Editor {


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        this.serializedObject.ApplyModifiedProperties();
    }



}
