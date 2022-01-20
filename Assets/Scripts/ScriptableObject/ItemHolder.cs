using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ItemSlot
{
    public Item item;
    public int amount; 
}

[CreateAssetMenu(fileName = "Inventory", menuName = "Assets/ItemHolder")]
public class ItemHolder : ScriptableObject
{
    public List<ItemSlot> slots;
}
