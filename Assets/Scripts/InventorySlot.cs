using System;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image slotImage;
    public Text slotText;
    private int _itemCount;

    public string ItemName { get; set; }

    public int Count
    {
        get => _itemCount;
        set
        {
            _itemCount = Math.Max(value, 0);
            if (_itemCount > 1)
            {
                slotText.text = _itemCount + "x";
            }
            else
            {
                slotText.text = "";
                if (value == 1) 
                    return;
                slotImage.sprite = null;
                ItemName = "";

            }
        }
    }
}
