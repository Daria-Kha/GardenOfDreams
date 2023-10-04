using UnityEngine;


public class InvScr : MonoBehaviour
{
    public InventorySlot[] inventory;
   // public Sprite defaultIcon;


    public void AddItem(in Item item)
    {
        InventorySlot slot = null;
        foreach (var invSlot in inventory)
        {
            if (!IsSameItem(invSlot, item))
                continue;
            slot = invSlot;
            break;
        }

        if (slot == null)
            AddToInventory(item);
        else
            slot.Count++;
        
    }

    private static bool IsSameItem(in InventorySlot first, in Item second)
    {
        return first.ItemName == second.itemName;
    }

    private void AddToInventory(in Item item)
    {
        foreach (var inventorySlot in inventory)
        {
            if (inventorySlot.Count != 0) 
                continue;

            inventorySlot.ItemName = item.itemName;
            inventorySlot.slotImage.sprite = item.icon;
            inventorySlot.Count = 1;
            break;
        }
    }

    public void RemoveItem(in int index)
    {
        inventory[index].Count = 0;
    }
}









