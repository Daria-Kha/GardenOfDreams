using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public Sprite icon;

    public void UseItem()
    {
        Debug.Log("used");
    }
}
