using UnityEditor;

public class SlothScene : Editor
{
    /// <summary>
    /// 设置场景中使用的纹理可读属性
    /// </summary>
    [MenuItem("Sloth/Scene/Set ActiveScene Texture read")]
    static void SetActiveSceneTextureRead()
    {
        SceneUtil.SetActiveSceneTextureRead();
    }

    [MenuItem("Sloth/Scene/Check ActiveScene Texture Reference Lose")]
    static void CheckTextureReferenceLose()
    {
        SceneUtil.CheckTextureReferenceLose();
    }

    [MenuItem("Sloth/Scene/Write BakeLightmap Data")]
    static void WriteBakeLightmapData()
    {
        if(EditorUtility.DisplayDialog("警告", "重置场景灯光焙倍，将影响场景效果，是否继续", "继续", "取消"))
        {
            BakedLightmapUtil.WriteBakeLightmap();
        }
    }

    [MenuItem("Sloth/Scene/导出选中对象路径 - 未删前")]
    static void ExportSceneSelectObjs()
    {
        SceneUtil.ExportSceneSelectObjs("top");
    }

    [MenuItem("Sloth/Scene/导出选中对象路径 - 删除后")]
    static void ExportSceneSelectObjs2()
    {
        SceneUtil.ExportSceneSelectObjs("back");
    }

    [MenuItem("Sloth/Scene/CheckDelect Form JSON")]
    static void CheckDelectFormJSON()
    {
        SceneUtil.CheckDelectFormJSON();
    }

    [MenuItem("Sloth/Scene/Handle Delect Objects")]
    static void HandleDelectObjects()
    {
        SceneUtil.HandleDelectObjects();
    }

    [MenuItem("Sloth/Scene/Export Gameobject uid")]
    static void ExportGameobjectUID()
    {
        SceneUtil.ExportGameobjectUID();
    }
}
