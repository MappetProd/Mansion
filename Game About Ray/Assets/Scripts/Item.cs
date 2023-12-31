using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    [Header("Only gameplay")]
    public TileBase tile;
    public ItemType type;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]
    public Sprite image;
    public GameObject prefabOfObj;
}
public enum ItemType
{
    Key,
    Note,
    Artifact
}
