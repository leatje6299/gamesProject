using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Food,
    Journal,
    Pole,
    Empty
}

[CreateAssetMenu(fileName ="Inventory", menuName ="Assets/Inventory")]
public class Inventory : ScriptableObject
{
   

    [SerializeField]
    public int numberOfSlots = 4;
    public int currentSlot = 0;

    private void Awake()
    {
        ItemType[] itemType;

        itemType[0] = ItemType.Empty;
        itemType[1] = ItemType.Empty;
        itemType[2] = ItemType.Empty;
        itemType[3] = ItemType.Empty;
    }
}
