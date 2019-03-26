using UnityEngine;
using UnityEditor;
using Foundation.Editor.AssetAudit;

public static class AssetMethod
{
    public static void Apply2(this ImageTextureSettings setting, AssetImporter assetImporter)
    {
        var ti = assetImporter as TextureImporter;
        if (ti != null)
        {
            var tis = new TextureImporterSettings();
            var tips = new TextureImporterPlatformSettings();
            var x = setting.settings;
            x.generalSettings.readable = true;
            setting.settings = x;
            setting.settings.Use(tis, tips);
            ti.SetPlatformTextureSettings(tips);
            ti.SetTextureSettings(tis);
        }
    }
}