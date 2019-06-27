using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlothCombineNodeWindow : EditorWindow {

    [MenuItem("Sloth/Window/CombineNodeWindow")]
    public static void CreateWindow()
    {
        SlothCombineNodeWindow win = EditorWindow.GetWindow<SlothCombineNodeWindow>(false, "CombineNodeWindow", true);
        win.Show();
    }
	


}
