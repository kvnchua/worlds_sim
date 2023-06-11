using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Interactable,
    Material,
    Usable,
    Wearable,
    Eatable,
    Sellable
}

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class ItemDatabase : ScriptableObject, IEntity
{
    public string EntityName { get { return itemName; } set { itemName = value; } }
    public string Description { get { return description; } set { description = value; } }
    public Sprite Icon { get { return icon; }  set { icon = value; } }

    [SerializeField]
    private string itemName;

    [SerializeField]
    private string description;

    [SerializeField]
    private Sprite icon;

    [SerializeField]
    private List<ItemType> itemTypes;
    

    public bool IsInteractable { get { return itemTypes.Contains(ItemType.Interactable);  } }

    public bool IsMaterial { get { return itemTypes.Contains(ItemType.Material); } }

    public bool IsUsable { get { return itemTypes.Contains(ItemType.Usable); } }

    public bool IsWearable { get { return itemTypes.Contains(ItemType.Wearable); } }

    public bool IsEatable { get { return itemTypes.Contains(ItemType.Eatable); } }

    public bool IsSellable { get { return itemTypes.Contains(ItemType.Sellable); } }
}