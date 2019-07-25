using UnityEditor;
[CanEditMultipleObjects, CustomEditor(typeof(SlothFragmentMono))]
public class SlothFragmentInspector : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        this.serializedObject.ApplyModifiedProperties();
    }

}
