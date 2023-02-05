using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton
    public static Inventory instance;
    
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public GameObject inventoryUI;

    InventorySlot[] slots;

    public Transform itemsParent;

    Inventory inventory;

    public AudioClip pickupObjectAudio;

    void Start()
    {
        inventoryUI.SetActive(false);

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        inventory = Inventory.instance;
    }

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            UpdateUI(item, true);

            AudioSource.PlayClipAtPoint(pickupObjectAudio, transform.position);

            items.Add(item);
            
        }
        return true;
    }
    
    
    public void Remove(Item item)
    {
        items.Remove(item);

        UpdateUI(item, false);

    }

    public void OnClickItems()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }


    public void UpdateUI(Item item, bool addOrRemove)
    {
        Debug.Log("UPDATING UI");
        
        for (int i = 0; i < slots.Length; i++)
        {
            Debug.Log("i: " + i);
            //Debug.Log("inv items number " + inventory.items.Count);
            if (i < 16)
            {
                // if there is no item in the spot yet
                if (slots[i].itemName == "" && addOrRemove) 
                {   
                    Debug.Log("Empty Slot Filling");
                    slots[i].AddItem(item);
                    break;
                // if the current slot has the same item
                } else if (slots[i].itemName == item.name)
                {
                    if (addOrRemove)
                    {
                        Debug.Log("Adding " + item.name + " to slot " + i);
                        slots[i].UpdateItem();
                    }  else if (!addOrRemove)
                    {
                        Debug.Log("Removing " + item.name + " from slot " + i);
                        slots[i].RemoveItem();
                    }
                    break;
                }
            }
        }
        
    }



}
