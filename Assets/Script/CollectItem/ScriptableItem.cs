using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item",menuName ="ScriptableItem",order = 1)]
public class ScriptableItem : ScriptableObject
{
    public int keyItem;
    public int item;

    private void OnEnable()
    {
        keyItem = 0;
    }
}
