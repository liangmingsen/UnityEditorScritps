using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlothFragment : Editor
{
    [MenuItem("Sloth/Fragment/Bind Fragment Script Auto")]
    static void BindFragmentScript()
    {
        FragmentUtil.AutoBindFragmentScript();
    } 
    [MenuItem("Sloth/Fragment/Calculation Object Fragment indexs")]
    static void CalculationObjectFragmentIndexs()
    {
        if(EditorUtility.DisplayDialog("警告","重新计算将覆盖人工修改的参数", "继续", "取消"))
        {
            FragmentUtil.CalculationObjectFragmentIndexs();
        }
    }
    [MenuItem("Sloth/Fragment/UnBind Fragment Script")]
    static void UnBindFragmentScript()
    {
        if (EditorUtility.DisplayDialog("警告", "是否继续删除绑定的 SlothFragmentMono 脚本", "继续", "取消"))
        {
            FragmentUtil.UnBindSlothFragmentMonoscript();
        }   
    }
    [MenuItem("Sloth/Fragment/Read File Tag Fragment Script")]
    static void ReadFileTagFragmentFileScript()
    {
        if (EditorUtility.DisplayDialog("警告", "是否还原脚本，将清空当前脚本设置", "继续", "取消"))
        {
            FragmentUtil.UnBindSlothFragmentMonoscript();
            FragmentUtil.ReductionSlothScript();
        }
    }


}
