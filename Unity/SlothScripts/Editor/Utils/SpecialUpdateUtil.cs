using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpecialUpdateUtil {

    public static void ExportJson()
    {
        List<GameObject> gos = SceneUtil.GetActiveSceneAllGO();
        if(gos != null)
        {
            List<string> paths = new List<string>();
            SlothSpecialUpdateMono mono = null;
            foreach (GameObject g in gos)
            {
                mono = g.GetComponent<SlothSpecialUpdateMono>();
                if(mono != null)
                {
                    if (mono.IsSpecial)
                    {
                        paths.Add(FileUtils.GetGameObjectPath(g));
                    }
                }
            }

            StreamWriter sw = FileUtils.GetSpecialFile();
            Umeng.JSONArray rootJson = new Umeng.JSONArray();
            
            int length = paths.Count;
            for (int i = 0; i < length; i++)
            {
                rootJson.Add(paths[i]);
            }
            sw.Write(rootJson.ToString());
            sw.Close();
            Application.OpenURL(FileUtils.GetSpecialFilePath());
            Debug.Log("特殊更新完毕 导出数量:" + paths.Count);
        }
    }

    public static void RemoveAllTagSpecialScript()
    {
        List<GameObject> gos = SceneUtil.GetActiveSceneAllGO();
        if (gos != null)
        {
            SlothSpecialUpdateMono mono = null;
            int count = 0;
            foreach (GameObject g in gos)
            {
                mono = g.GetComponent<SlothSpecialUpdateMono>();
                if (mono != null)
                {
                    GameObject.DestroyImmediate(mono);
                    count++;
                }
            }
            Debug.Log("删除特殊脚本数量:" + count);
        }
    }


}
