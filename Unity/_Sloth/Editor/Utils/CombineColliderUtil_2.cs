using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CombineColliderUtil_2 : CombineColliderUtil {


    public static void CombineBigCollider_grid_12()
    {
        Transform parent = GameObject.Find("Grid_12").transform;
        User.TileMap.Grid g = parent.GetComponent<User.TileMap.Grid>();
        Vector3 size = new Vector3(5, 1, g.m_x);
        Vector3 center = new Vector3(0,-0.5f,0);
        Vector3 localPos = new Vector3(10.5f, 0.25f, g.m_x/2);

        CreateBigBox("Waltz_Tile_Empty1x1_grid_12", localPos, parent, center, size);
        CreateCheckBox(5, g.m_x, new Vector3(0, -0.5f, 0), new Vector3(1, 1, 1));
        GetChildColliderGos<WideTilePro>();
        List<string> removeMissList = new List<string>() { "3,46", "3,47" };
        CheckTabBox(removeMissList);//跨界的，要特殊处理。
        SetMissTilesToWideTilePro(g.m_id);
    }

    public static void CombineBigCollider_grid_13()
    {
        Transform parent = GameObject.Find("Grid_13").transform;
        User.TileMap.Grid g = parent.GetComponent<User.TileMap.Grid>();
        Vector3 size = new Vector3(5, 1, g.m_x);
        Vector3 center = new Vector3(0, -0.5f, 0);
        Vector3 localPos = new Vector3(10.5f, 0.25f, g.m_x / 2);

        CreateBigBox("Waltz_Tile_Empty1x1_grid_13", localPos, parent, center, size);
        CreateCheckBox(5, g.m_x, new Vector3(0, -0.5f, 0), new Vector3(1, 1, 1));
        GetChildColliderGos<WideTilePro>();
        List<string> removeMissList = new List<string>() { "2,36"};
        CheckTabBox(removeMissList);
        SetMissTilesToWideTilePro(g.m_id);
    }

    public static void CombineBigCollider_grid_14()
    {
        Transform parent = GameObject.Find("Grid_14").transform;
        User.TileMap.Grid g = parent.GetComponent<User.TileMap.Grid>();
        int sizeX = 3;
        Vector3 size = new Vector3(sizeX, 1, g.m_x);
        Vector3 center = new Vector3(0, -0.5f, 0);
        Vector3 localPos = new Vector3(10.5f, 0.25f, g.m_x / 2);

        CreateBigBox("Waltz_Tile_Empty1x1_grid_14", localPos, parent, center, size);
        CreateCheckBox(sizeX, g.m_x, center, Vector3.one);
        GetChildColliderGos<WideTilePro>();
        GetChildColliderGos<NormalTile>();
        List<string> removeMissList = new List<string>() { "1,5", "2,17", "0,29", "0,41", "1,53", "2,59", "2,67", "1,67", "0,67" };
        CheckTabBox(removeMissList);
        SetMissTilesToWideTilePro(g.m_id);
    }

    public static void CombineBigCollider_grid_15()
    {
        Transform parent = GameObject.Find("Grid_15").transform;
        User.TileMap.Grid g = parent.GetComponent<User.TileMap.Grid>();
        int sizeX = 3;
        Vector3 size = new Vector3(sizeX, 1, g.m_x);
        Vector3 center = new Vector3(0, -0.5f, 0);
        Vector3 localPos = new Vector3(10.5f, 0.25f, g.m_x / 2);

        CreateBigBox("Waltz_Tile_Empty1x1_grid_15", localPos, parent, center, size);
        CreateCheckBox(sizeX, g.m_x, center, Vector3.one);
        GetChildColliderGos<WideTilePro>();
        GetChildColliderGos<NormalTile>();
        List<string> removeMissList = new List<string>() { "1,4", "1,10", "2,45" };
        CheckTabBox(removeMissList);
        SetMissTilesToWideTilePro(g.m_id);
    }

    public static void CombineBigCollider_grid_16()
    {
        Transform parent = GameObject.Find("Grid_16").transform;
        User.TileMap.Grid g = parent.GetComponent<User.TileMap.Grid>();
        int sizeX = 3;
        Vector3 size = new Vector3(sizeX, 1, g.m_x);
        Vector3 center = new Vector3(0, -0.5f, 0);
        Vector3 localPos = new Vector3(10.5f, 0.25f, g.m_x / 2);

        CreateBigBox("Waltz_Tile_Empty1x1_grid_16", localPos, parent, center, size);
        CreateCheckBox(sizeX, g.m_x, center, Vector3.one);
        GetChildColliderGos<WideTilePro>();
        GetChildColliderGos<NormalTile>();
        List<string> removeMissList = new List<string>() { "2,1", "1,13", "1,25", "1,37", "1,49" };
        CheckTabBox(removeMissList);
        SetMissTilesToWideTilePro(g.m_id);
    }



}
