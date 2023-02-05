using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    public Transform itemsParent;
    
    Inventory inventory;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

    }

    public void UpdateUI()
    {
        Debug.Log("UPDATING UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                if (slots[i].itemName != "")
                {
                    Debug.Log("adding " + inventory.items[i].name + " at " + i);
                    Debug.Log(slots[i].itemName == "");
                    //Debug.Log(inventory.items[1].name == slots[i].itemName);
                    //slots[i].UpdateItem();
                } else
                {
                    slots[i].AddItem(inventory.items[i]);
                }
            } else
            {
                slots[i].ClearSlot();
            }
        }
    }


}
