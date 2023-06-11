using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemDatabase itemDatabase;

    [SerializeField]
    private SpriteRenderer ItemIcon;

    private void Awake()
    {
        ItemIcon.sprite = itemDatabase.Icon;
    }

    public bool IsInteractable { get { return itemDatabase.IsInteractable; } }

    public bool IsMaterial { get { return itemDatabase.IsMaterial; } }

    public bool IsUsable { get { return itemDatabase.IsUsable; } }

    public bool IsWearable { get { return itemDatabase.IsWearable; } }

    public bool IsEatable { get { return itemDatabase.IsEatable; } }

    public bool IsSellable { get { return itemDatabase.IsSellable; } }
}
