using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlothSpecialUpdate : Editor {

    [MenuItem("Sloth/Export/Export Special Update JSON")]
    static void ExportTagSpecialJson()
    {
        SpecialUpdateUtil.ExportJson();
    }

    [MenuItem("Sloth/Special/Export All Begin Special Script")]
    static void RemoveTagSpecialScript()
    {
        SpecialUpdateUtil.RemoveAllTagSpecialScript();
    }

}
