using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Database/Data")]
public class ItemAsset : ScriptableObject
{
    public List<ItemData> data;
}
