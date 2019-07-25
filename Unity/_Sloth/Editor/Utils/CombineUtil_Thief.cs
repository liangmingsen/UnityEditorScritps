using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineUtil_Thief : CombineUtil_Thief_2_H
{
    //FreeCollideAnimTile
    public static void Combine_FreeCollideAnimTile(Transform[] tfs)
    {
        foreach (Transform t in tfs)
        {
            bool a = CheckChildFoNames(t, new string[] { "collider", "triggerPoint", "model" });
            bool b = CheckTargetComponentAndChildsCount<RS2.CoupleFollowTrigger>(t, 52);
            if (a && b)
            {
                Transform triggerPoint = t.Find("triggerPoint");
                Transform collider = t.Find("collider");
                BoxCollider bc = collider.GetComponent<BoxCollider>();

                bool d2 = CheckTargetComponentCount<Transform>(triggerPoint, 1);
                bool e2 = CheckTargetComponentAndChildsCount<Transform>(triggerPoint, 1);

                if (d2 && e2 && bc == null)
                {
                    DestroyGameObject(collider.gameObject);
                    DestroyGameObject(triggerPoint.gameObject);
                }
            }
        }
        DebugLog();
    }

}
