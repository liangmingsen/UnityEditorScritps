using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class FileUtil {
    private static string filepath = Application.dataPath + @"/_Sloth/Editor/export.txt";
    private static string staticFilePath = Application.dataPath + @"/_Sloth/ExportJson/tagStatic.txt";
    private static string staticFilePathAsset = @"Assets/_Sloth/ExportJson/tagStatic.txt";
    private static string lightmapDataFilePath = Application.dataPath + @"/_Sloth/ExportJson/lightmapData.txt";
    private static string lightmapDataFilePathAsset = @"Assets/_Sloth/ExportJson/lightmapData.txt";
    private static string particleFilePath = Application.dataPath + @"/_Sloth/ExportJson/particles.txt";
    private static string FragmentFilePath = Application.dataPath + @"/_Sloth/ExportJson/fragment.txt";
    private static string FragmentFilePathAsset = @"Assets/_Sloth/ExportJson/fragment.txt";

    private static void checkFile()
    {
        if (File.Exists(filepath))
        {
            File.Delete(filepath);
        }
    }

    public static string GetFragmentFilePathAsset()
    {
        return FragmentFilePathAsset;
    }

    public static string GetFragmentFilePath()
    {
        return FragmentFilePath;
    }

    public static StreamWriter GetFragmentFile()
    {
        checkFile();
        return new StreamWriter(FragmentFilePath);
    }

    public static StreamWriter GetParticleFile()
    {
        checkFile();
        return new StreamWriter(particleFilePath);
    }

    public static string GetParticleFilePath()
    {
        return particleFilePath;
    }

    public static string GetLightmapDataPath()
    {
        return lightmapDataFilePath;
    }

    public static string GetLightmapDataPathAsset()
    {
        return lightmapDataFilePathAsset;
    }

    public static StreamWriter GetLightmapDataFile()
    {
        checkFile();
        return new StreamWriter(lightmapDataFilePath);
    }

    public static string GetTagStaticPath()
    {
        return staticFilePath;
    }

    public static string GetTagStaticAssetPath()
    {
        return staticFilePathAsset;
    }

    public static StreamWriter GetTagStaticFile()
    {
        checkFile();
        return new StreamWriter(staticFilePath);
    }

    public static string GetTempFilePath()
    {
        return filepath;
    }

    public static StreamWriter GetTempFile()
    {
        checkFile();
        return new StreamWriter(filepath);
    }

    /// <summary>
    /// 返回对象 详细路径
    /// </summary>
    /// <param name="go"></param>
    /// <returns></returns>
    public static string GetGameObjectPath(GameObject go)
    {
        StringBuilder paths = new StringBuilder();
        GetParentName(go.transform, paths);
        paths.Append(go.transform.name);
        return paths.ToString();
    }

    private static void GetParentName(Transform tf, StringBuilder pathStr)
    {
        if (tf != null)
        {
            if (tf.parent != null)
            {
                pathStr.Insert(0, tf.parent.name + "#");
                GetParentName(tf.parent, pathStr);
            }
        }
    }

}
