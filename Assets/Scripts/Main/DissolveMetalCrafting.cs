using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DissolveMetalCrafting : MonoBehaviour
{
    InventorySlot[] slots;
    public Transform itemsParent;
    Inventory inventory;

    bool hasDragonfruit = false;
    bool hasBrownMushroom = false;
    bool hasYellowApple = false;
    bool hasLeaf = false;
    bool hasWalnut = false;

    public bool dissolveMetalCrafted = false;

    public string remainingItems;

    public GameObject helpMessageUI;
    public TextMeshProUGUI helpMessageText;

    public GameManager gm;

    public GameObject craftButton;

    public AudioSource craftAudio;

    public GameObject potionCraftedImage;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        potionCraftedImage.SetActive(false);
    }

    public void OnClickCraftDissolveMetal()
    {
        remainingItems = "Remaining: ";
        for (int i = 0; i < slots.Length; i++)
        {
            
            if (i < 16)
            {
                string currItem = slots[i].itemName;
                // if there is no item in the spot, rest of spots will be empty
                if (currItem == "") 
                {   
                    helpMessageUI.SetActive(true);
                    if (!hasDragonfruit)
                        remainingItems = string.Concat(remainingItems, "\n-Dragonfruit ");
                    if (!hasBrownMushroom)
                        remainingItems = string.Concat(remainingItems, "\n-Brown Mushroom ");
                    if (!hasYellowApple)
                        remainingItems = string.Concat(remainingItems, "\n-Yellow Apple ");
                    if (!hasLeaf)
                        remainingItems = string.Concat(remainingItems, "\n-Leaf ");
                    if (!hasWalnut)
                        remainingItems = string.Concat(remainingItems, "\n-Walnut ");
                    if (!dissolveMetalCrafted)
                    {
                        helpMessageText.text = remainingItems;
                    }
                    break;
                // if the current slot has one of the items, set corresponding bool
                } else 
                {
                    if (currItem == "Dragonfruit")
                        hasDragonfruit = true;
                    if (currItem == "Brown Mushroom")
                        hasBrownMushroom = true;
                    if (currItem == "Yellow Apple")
                        hasYellowApple = true;
                    if (currItem == "Leaf")
                        hasLeaf = true;
                    if (currItem == "Walnut")
                        hasWalnut = true;

                }

                if (hasDragonfruit && hasBrownMushroom && hasYellowApple && hasLeaf && hasWalnut)
                {
                    //helpMessageUI.SetActive(true);
                    dissolveMetalCrafted = true;
                    gm.dissolveMetalCrafted = true;
                    //helpMessageText.text = "Successfully gained ability to dissolve metal objects.";
                    craftAudio.Play(0);
                    craftButton.SetActive(false);
                    gm.middleQuestDone = true;
                    StartCoroutine(DisplayPotionEffect());

                    // remove all the items
                    bool dragonfruitRemoved = false;
                    bool brownMushroomRemoved = false;
                    bool yellowAppleRemoved = false;
                    bool leafRemoved = false;
                    bool walnutRemoved = false;
                    for (int j = 0; j < slots.Length; j++) 
                    {
                        if (j < 16)
                        {
                            currItem = slots[j].itemName;
                            if (currItem == "Dragonfruit" && !dragonfruitRemoved)
                            {
                                Inventory.instance.Remove(slots[j].GetItem());
                                dragonfruitRemoved = true;
                            }
                            if (currItem == "Brown Mushroom" && !brownMushroomRemoved)
                            {
                                Inventory.instance.Remove(slots[j].GetItem());
                                brownMushroomRemoved = true;
                            }
                            if (currItem == "Yellow Apple" && !yellowAppleRemoved)
                            {
                                Inventory.instance.Remove(slots[j].GetItem());
                                yellowAppleRemoved = true;                               
                            }
                            if (currItem == "Leaf" && !leafRemoved)
                            {
                                Inventory.instance.Remove(slots[j].GetItem());
                                leafRemoved = true;
                            }
                            if (currItem == "Walnut" && !walnutRemoved)
                            {
                                Inventory.instance.Remove(slots[j].GetItem());
                                walnutRemoved = true;
                            }
                        }
                    }

                    break;
                }
                
            }
            
        }
    }

    IEnumerator DisplayPotionEffect()
    {
        potionCraftedImage.SetActive(true);
        yield return new WaitForSeconds(1);
        potionCraftedImage.SetActive(false);
    }

}
