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

    [MenuItem("Sloth/Export/Export Particle JSON")]
    static void ExportParticleObjects()
    {
        ExportUtil.ExportParticleObjects();
    }

    [MenuItem("Sloth/Export/Export Fragment JSON")]
    static void ExportFragmentObjects()
    {
        FragmentUtil.ExportFragmentData();
    }

}