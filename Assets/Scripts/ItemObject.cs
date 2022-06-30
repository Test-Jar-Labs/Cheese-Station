using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [SerializeField]
    private InventoryItemData referenceItem;

    public void OnHandlePickupItem(InventorySystem inventory)
    {
        inventory.Add(referenceItem);
        Destroy(gameObject);
    }
}
