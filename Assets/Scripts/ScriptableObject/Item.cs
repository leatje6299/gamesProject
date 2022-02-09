using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SCRIPT BY LEA

[CreateAssetMenu(fileName = "Item", menuName = "Assets/Item")]
public class Item : ScriptableObject
{
    public GameObject type;
    public string Name;
    public bool stackable;
    public Sprite sprite;
}
