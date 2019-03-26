using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlothTag : Editor
{
    [MenuItem("Sloth/Tag/UnTag GameObject Static")]
    static void UnTabGameObjectStatic()
    {
        TagUtil.UnTabObjectStatic();
    }
    [MenuItem("Sloth/Tag/Tag GameObject Static")]
    static void TabGameObjectStatic()
    {
        TagUtil.TagObjectStatic();
    }
    [MenuItem("Sloth/Tag/Remove SlothTagMono Script")]
    static void RemoveSlothTagMono()
    {
        TagUtil.RemoveSlothTagMono();
    }


}
