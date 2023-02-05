using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DarkVisionCrafting : MonoBehaviour
{
    InventorySlot[] slots;
    public Transform itemsParent;
    Inventory inventory;

    bool hasYellowBellPepper = false;
    bool hasDandelions = false;
    int numDandelions = 0;
    bool hasOnion = false;
    bool hasLarkspur = false;

    public bool darkVisionCrafted = false;

    public string remainingItems;

    public GameObject helpMessageUI;
    public TextMeshProUGUI helpMessageText;

    public GameManager gm;

    public GameObject craftButton;

    public GameObject forestBorder;

    public AudioSource craftAudio;

    public GameObject potionCraftedImage;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        potionCraftedImage.SetActive(false);
    }

    public void OnClickCraftDarkVision()
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
                    if (!hasYellowBellPepper)
                        remainingItems = string.Concat(remainingItems, "\n-Yellow Bell Pepper ");
                    if (!hasDandelions)
                        remainingItems = string.Concat(remainingItems, "\n-Dandelion ");
                    if (numDandelions == 0)
                        remainingItems = string.Concat(remainingItems, "\n-Dandelion ");
                    if (!hasOnion)
                        remainingItems = string.Concat(remainingItems, "\n-Onion ");
                    if (!hasLarkspur)
                        remainingItems = string.Concat(remainingItems, "\n-Larkspur ");
                    if (!darkVisionCrafted)
                    {
                        helpMessageText.text = remainingItems;
                    }
                    break;
                // if the current slot has one of the items, set corresponding bool
                } else 
                {
                    if (currItem == "Yellow Bell Pepper")
                        hasYellowBellPepper = true;
                    if (currItem == "Dandelion")
                    {
                        numDandelions = 1;
                        if (slots[i].count > 1)
                            hasDandelions = true;
                    }
                    if (currItem == "Onion")
                        hasOnion = true;
                    if (currItem == "Larkspur")
                        hasLarkspur = true;
                }
                if (hasYellowBellPepper && hasDandelions && hasOnion && hasLarkspur)
                {
                    //helpMessageUI.SetActive(true);
                    darkVisionCrafted = true;
                    gm.darkVisionCrafted = true;
                    //helpMessageText.text = "Successfully Gained Dark Vision";
                    craftAudio.Play(0);
                    craftButton.SetActive(false);
                    forestBorder.SetActive(false);
                    gm.startQuestDone = true;
                    StartCoroutine(DisplayPotionEffect());

                    // remove all the items
                    bool yellowBellPepperRemoved = false;
                    bool dandelionsRemoved = false;
                    bool onionRemoved = false;
                    bool larkspurRemoved = false;
                    for (int j = 0; j < slots.Length; j++) 
                    {
                        if (j < 16)
                        {
                            currItem = slots[j].itemName;
                            if (currItem == "Dandelion" && !dandelionsRemoved)
                            {
                                Inventory.instance.Remove(slots[j].GetItem());
                                Inventory.instance.Remove(slots[j].GetItem());
                                dandelionsRemoved = true;
                            }
                            if (currItem == "Yellow Bell Pepper" && !yellowBellPepperRemoved)
                            {
                                Inventory.instance.Remove(slots[j].GetItem());
                                yellowBellPepperRemoved = true;
                            }
                            if (currItem == "Onion" && !onionRemoved)
                            {
                                Inventory.instance.Remove(slots[j].GetItem());
                                onionRemoved = true;                               
                            }
                            if (currItem == "Larkspur" && !larkspurRemoved)
                            {
                                Inventory.instance.Remove(slots[j].GetItem());
                                larkspurRemoved = true;
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
