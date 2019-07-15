using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using Umeng;

public partial class Sloth : Editor
{
    [MenuItem("Sloth/Export/Export StaticJson JSON")]
    static void ExportTagStaticJson()
    {
        ExportUtil.ExportTagSaticObject();
    }

    [MenuItem("Sloth/Export/Export BakeLightmap JSON")]
    static void ExportReadBakedLightmap()
    {
        BakedLightmapUtil.ReadBakedLightmap();
    }

    [MenuItem("Sloth/Export/Select Export BakeLightmap JSON")]
    static void ExportReadBakedLightmapSelect()
    {
        BakedLightmapUtil.ReadBakedLightmap(Selection.gameObjects, true);
    }

    //[MenuItem("Sloth/Export/Export Particle JSON")]
    static void ExportParticleObjects()
    {
        ExportUtil.ExportParticleObjects();
    }

    [MenuItem("Sloth/Export/Export Fragment JSON")]
    static void ExportFragmentObjects()
    {
        FragmentUtil.ExportFragmentToJson();
    }

    [MenuItem("Sloth/Export/L2/Export New GridGroup")]
    static void ExportNewGridNodes_Level2()
    {
        NodeUtil.ExportNewGridNodes(2);
    }

}