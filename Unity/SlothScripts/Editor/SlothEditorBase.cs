using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlothEditorBase : Editor {

	

    protected static bool CheckDisplayDialog(string title="", string message= "后果自负", string ok= "继续", string cancel="取消")
    {
        return EditorUtility.DisplayDialog(title, message, ok, cancel);
    }

}
