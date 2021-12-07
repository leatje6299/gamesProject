using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Inventory", menuName ="Assets/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField]
    public int[] numberOfSlots; 

}
