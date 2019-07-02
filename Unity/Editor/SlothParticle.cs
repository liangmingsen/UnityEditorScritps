using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SlothCheck : Editor {

    //[MenuItem("Sloth/Particle/Export ActiveScene Particle UnMaterial List")]
    static void ExportActiveSceneParticleListUnMaterial()
    {
        ParticleUtil.ExportActiveSceneParticleListUnMaterial();
    }

    [MenuItem("Sloth/Particle/Export ActiveScene Particle Material List")]
    static void ExportActiveSceneParticleListMaterial()
    {
        ParticleUtil.ExportActiveSceneParticleListMaterial();
    }

    //[MenuItem("Sloth/Particle/Export ActiveScene Particle Mesh List")]
    static void ExportActiveSceneParticleMeshList()
    {
        ParticleUtil.ExportActiveSceneParticleListMesh();
    }

    [MenuItem("Sloth/Particle/Destroy ActiveScene Particle")]
    static void DestroyActiveSceneParticle()
    {
        if(EditorUtility.DisplayDialog("警告", "是否删除所有粒子特效对象", "确定", "取消"))
        {
            ParticleUtil.DestroyActiveSceneParticle();
        }
    }

    [MenuItem("Sloth/Particle/Get ActiveScene Particle Count")]
    static void GetParticleCount()
    {
        ParticleUtil.GetParticleCount();
    }

    [MenuItem("Sloth/Particle/Destroy ActiveScene UnActive Particle")]
    static void DestroyActiveSceneUnActiveParticle()
    {
        if (EditorUtility.DisplayDialog("警告", "是否删除未激活的粒子特效对象", "确定", "取消"))
        {
            ParticleUtil.DestroyActiveSceneUnActiveParticle();
        }
    }

}
