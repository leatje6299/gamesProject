using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Assets/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public bool stackable;
    public Sprite sprite;
}
