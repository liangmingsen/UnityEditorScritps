using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlothCombine : Editor {

    [MenuItem("Sloth/Combine/Combine Childs model&collider")]
    static void UnActiveGameObjectCount()
    {
        CombineUtil.CombineChilds();
    }


}
