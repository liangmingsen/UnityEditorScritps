using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 利用 GL 画 图案。
/// </summary>
public class DrawingGL : MonoBehaviour
{
    /// <summary>
    /// 可重新指定线条材质，不指定，则使用默认材质。
    /// </summary>
    public Material lineMaterial;
    /// <summary>
    /// 线条位置数组
    /// </summary>
    private Vector3[] _linePosList;
    /// <summary>
    /// 线条颜色
    /// </summary>
    private Color _lineColor ;

    private void Start()
    {
        _lineColor = new Color(1,0,0,1);
        CEventUtil.AddListener(CEventName.DRAW_SHAPE, _HandleCEvent);
    }

    private void OnDestroy()
    {
        CEventUtil.RemoveListener(CEventName.DRAW_SHAPE, _HandleCEvent);
    }

    private void OnRenderObject()
    {
        if (_linePosList == null || _linePosList.Length <= 1)
            return;

        if (lineMaterial == null)
            CreateLineMaterial();

        GL.PushMatrix();
        //设置要绘制到的 变形矩阵中。
        //GL.MultMatrix(transform.localToWorldMatrix);
        //帮助函数,设置一个正交透视变换。
        GL.LoadOrtho();
        //应用线条材质。
        lineMaterial.SetPass(0);

        GL.Begin(GL.LINES);
        {
            int length = _linePosList.Length - 1;
            Vector3 cur;
            Vector3 next;
            for (int i = 0; i < length; i++)
            {
                cur = _linePosList[i];
                next = _linePosList[i + 1];
                GL.Color(_lineColor);
                GL.Vertex3(cur.x, cur.y, cur.z);
                GL.Vertex3(next.x, next.y, next.z);
            }
        }
        GL.End();
        GL.PopMatrix();
    }

    public void ClearDraw()
    {
        _linePosList = null;
    }

    private void _HandleCEvent(ICEventArgs args)
    {
        _linePosList = ((DrawShapePoint)args).pointList;
    }

    /// <summary>
    /// 创建线条材质
    /// </summary>
    private void CreateLineMaterial()
    {
        if(lineMaterial == null)
        {
            Shader shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            //隐藏标记 -- 不显示在hierarchy面板中的组合，不保存到场景并且卸载Resources.UnloadUnusedAssets不卸载的对象。
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            //打开alpha混合
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            //关闭背面剔除
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            //关闭深度写入
            lineMaterial.SetInt("_ZWrite", 0);
        }
    }

    #region test code
    private void OnRenderObjectTest()
    {
        if (lineMaterial == null)
            CreateLineMaterial();

        //应用线条材质。
        lineMaterial.SetPass(0);
        //
        GL.PushMatrix();
        //设置要绘制到的 变形矩阵中。
        GL.MultMatrix(transform.localToWorldMatrix);

        GL.Begin(GL.LINES);
        {
            float lineCount = 100.0f;
            for (int i = 0; i < lineCount; i++)
            {
                float a = i / lineCount;
                float angle = a * Mathf.PI * 2;
                GL.Color(new Color(a, 1 - a, 0, 0.8f));
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(Mathf.Cos(angle) * 5, Mathf.Sin(angle) * 5, 0);
            }
        }
        GL.End();
        GL.PopMatrix();
    }
    #endregion
}
