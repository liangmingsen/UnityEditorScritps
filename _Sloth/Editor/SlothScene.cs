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
}
