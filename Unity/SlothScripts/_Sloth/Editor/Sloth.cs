using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;

public partial class Sloth : Editor
{
    [MenuItem("Sloth/About")]
    static void About()
    {
        Application.OpenURL("https://space.bilibili.com/4300952/#/");
    }
}