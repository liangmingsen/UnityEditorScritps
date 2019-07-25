using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlothCombine : Editor
{

    //只有两个节点，分别是 model 和 collider 。然后把 其中名字叫collider的身上的 collider 组件 复制到父节点，后删除这两个节点。
    [MenuItem("Sloth/Combine/copy collider")]
    static void CombineDelModelCopyCollidder()
    {
        CombineUtil.IsCheck = false;
        CombineUtil.CombineDelModelCopyCollidder();
    }
    //只有两个节点，分别是 model 和 collider 。然后把其中名字叫collider的身上的collider组件复制到父节点，和把名字叫model的身上的mesh复制到父节点，后删除这两个节点。
    [MenuItem("Sloth/Combine/copy mesh copy collider")] // Home_Road01
    static void CombineCopyCollidderCopyMesh()
    {
        CombineUtil.IsCheck = false;
        CombineUtil.CombineCopyCollidderCopyMesh();
    }
    //只有两个节点，分别是 model 和 collider 。然后把其中名字叫collider的身上的collider组件复制到父节点，和把名字叫model的身上的AudioSource复制到父节点，后删除这两个节点。
    [MenuItem("Sloth/Combine/copy Audio copy collider")] // Tile_P0_SuperJumpQTE(Clone)
    static void CombineCopyCollidderCopyAudio()
    {
        CombineUtil.IsCheck = false;
        CombineUtil.CombineCopyCollidderCopyAudio();
    }
    //只有三个节点，分别是 model 和 collider 。然后把其中名字叫collider的身上的collider组件复制到父节点，和把名字叫model的身上的AudioSource复制到父节点，后删除这两个节点和path节点。
    [MenuItem("Sloth/Combine/copy mesh copy collider del path")] // FreeMoveTile_Home03
    static void CombineCopyCollidderCopyMeshDelPath()
    {
        CombineUtil.IsCheck = false;
        CombineUtil.CombineCopyCollidderCopyMeshDelPath();
    }
    //只有一个节点，父节点没有AudioSource、mesh等，子节点有mesh。然后把子节点移动到与父同级，并改名。
    [MenuItem("Sloth/Combine/child node Replace Parent node")]
    static void ChildReplaceParentObj()
    {
        CombineUtil.IsCheck = false;
        CombineUtil.ChildReplaceParentObj();
    }

    //包含三个子节点 model \ collider \ triggerPoint
    [MenuItem("Sloth/Combine/Replace Destroy node")]
    static void ReplaceAndDestroy()
    {
        CombineUtil.IsCheck = false;
        CombineUtil.ReplaceAndDestroy();
    }

    //包含三个子节点 包含碱个子节点 model \ effect0 \ effect1
    [MenuItem("Sloth/Combine/Replace Destroy PuGongYing effect")]
    static void ReplaceAndDestroyPuGongYingEffect()
    {
        CombineUtil.IsCheck = false;
        CombineUtil.ReplaceAndDestroyPuGongYingEffect();
    }

    //包含5个子节点 model \ distanceEffect \ triggerEffect \ triggerPoint \ collider
    [MenuItem("Sloth/Combine/Replace Destroy Two Effect Trigger Pro")]
    static void ReplaceAndDestroyTwoEffectTriggerPro()
    {
        CombineUtil.IsCheck = false;
        CombineUtil.ReplaceAndDestroyTwoEffectTriggerPro();
    }

    //包含3个子节点 model \ collider \ triggerPoint
    [MenuItem("Sloth/Combine/Replace Destroy Anim Enemy Pro")]
    static void ReplaceAndDestroyAnimEnemyPro()
    {
        CombineUtil.IsCheck = false;
        CombineUtil.ReplaceAndDestroyAnimEnemyPro();
    }
}
