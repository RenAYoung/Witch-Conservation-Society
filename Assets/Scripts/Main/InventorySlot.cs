using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{

    public Image icon;
    
    Item item;

    public int count = 0;

    public TextMeshProUGUI numberText;

    public string itemName = "";

    public void AddItem(Item newItem)
    {
        count = 1;
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        numberText.text = count.ToString();
        itemName = item.name;
    }

    public void UpdateItem()
    {
        count += 1;
        numberText.text = count.ToString();
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

    }

    public Item GetItem()
    {
        return item;
    }

    public void RemoveItem()
    {
        if (count > 0)
        {
            count -= 1;
            numberText.text = count.ToString();
        } 
    }
}
