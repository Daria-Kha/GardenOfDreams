using UnityEngine;

public class SlotButton : MonoBehaviour
{
    public GameObject button;
    
    public void ActivateRemoveButton()
    {
        if (button == null)
            return;
        
        var isActive = button.activeSelf;
        button.SetActive(!isActive);
    }
}
