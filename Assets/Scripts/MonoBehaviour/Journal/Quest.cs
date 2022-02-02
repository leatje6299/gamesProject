using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "Assets/Quest")]
public class Quest : ScriptableObject
{
    public string title;
    public string description;
    public bool isCompleted;
    public bool isActive;
}
