using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject recipeBookPG1UI;
    public GameObject recipeBookPG2UI;
    public int currRecipePage = 1; // represents page to save as open

    public GameObject devOptionsUI;

    public GameObject helpMessageUI;
    public TextMeshProUGUI helpMessageText;

    public bool darkVisionCrafted = false;

    public bool dissolveMetalCrafted = false;

    public GameObject forestBorder;

    public GameObject caveDoorLocked;
    public GameObject caveDoorUnlocked;

    public bool firstItemPicked = false;

    public GameObject questsUI;
    
    public bool startQuestDone = false;
    public bool middleQuestDone = false;
    public bool endQuestDone = false;

    public GameObject startQuest;
    public GameObject startQuestNext;
    public GameObject startQuestCompleted;

    public GameObject middleQuest;
    public GameObject middleQuestNext;
    public GameObject middleQuestCompleted;

    public GameObject endQuest;
    public GameObject endQuestCompleted;

    int currentQuest = 1;

    public GameObject tipsUI;
    public TextMeshProUGUI tipText;
    public GameObject tipsPrevButton;
    public GameObject tipsNextButton;

    int currentTip = 1;
    int maxTipNum = 5;

    public GameObject darkVisionPotionCraftedImage;
    public GameObject dissolveMetalPotionCraftedImage;

    // Start is called before the first frame update
    void Start()
    {
        recipeBookPG1UI.SetActive(false);
        recipeBookPG2UI.SetActive(false);

        devOptionsUI.SetActive(false);

        helpMessageUI.SetActive(false);

        StartCoroutine(DisplayMovementHelp());

        caveDoorLocked.SetActive(true);
        caveDoorUnlocked.SetActive(false);

        questsUI.SetActive(false);
        startQuest.SetActive(false);
        startQuestCompleted.SetActive(false);
        startQuestNext.SetActive(false);
        middleQuest.SetActive(false);
        endQuest.SetActive(false);
        endQuestCompleted.SetActive(false);

        tipsUI.SetActive(false);
        
        darkVisionPotionCraftedImage.SetActive(false);
        dissolveMetalPotionCraftedImage.SetActive(false);

    }

    void Update()
    {
        if (startQuestDone == true)
        {
            startQuestCompleted.SetActive(true);
            startQuestNext.SetActive(true);
        }
        if (middleQuestDone == true)
        {
            middleQuestCompleted.SetActive(true);
            middleQuestNext.SetActive(true);
        }
        if (endQuestDone == true)
        {
            endQuestCompleted.SetActive(true);
        }
    }

    public void OnClickRecipeBook()
    {

        if (currRecipePage == 1)
            recipeBookPG1UI.SetActive(!recipeBookPG1UI.activeSelf);
        if (currRecipePage == 2)
            recipeBookPG2UI.SetActive(!recipeBookPG2UI.activeSelf);
        
    }

    public void OnClickNextRecipePage()
    {
        currRecipePage = 2;
        recipeBookPG1UI.SetActive(false);
        recipeBookPG2UI.SetActive(true);
    }

    public void OnClickPrevRecipePage()
    {
        currRecipePage = 1;
        recipeBookPG1UI.SetActive(true);
        recipeBookPG2UI.SetActive(false);
    }

    public void OnClickDevOptions()
    {
        devOptionsUI.SetActive(!devOptionsUI.activeSelf);
    }

    public void OnClickUnlockForest()
    {
        forestBorder.SetActive(false);
    }

    public void OnClickOpenPuzzle()
    {
        caveDoorLocked.SetActive(false);
        caveDoorUnlocked.SetActive(true);
    }

    public void onClickCloseHelpMessage()
    {
        helpMessageUI.SetActive(false);
        if (!firstItemPicked)
        {
            //helpMessageUI.SetActive(true);
            //helpMessageText.text = "Use 'E' to pickup items.";
            firstItemPicked = true;
        }
    }

    public void onClickQuests()
    {
        questsUI.SetActive(!questsUI.activeSelf);
        
        if (currentQuest == 1 && questsUI.activeSelf)
        {
            startQuest.SetActive(true);
        } else if (currentQuest == 2 && questsUI.activeSelf)
        {
            middleQuest.SetActive(true);
        } else if (currentQuest == 3 && questsUI.activeSelf)
        {
            endQuest.SetActive(true);
        }
        
    }

    public void onClickNextQuest()
    {
        if (currentQuest == 1)
        {
            startQuest.SetActive(false);
            middleQuest.SetActive(true);
            middleQuestCompleted.SetActive(false);
            middleQuestNext.SetActive(false);
            currentQuest = 2;
        } else if (currentQuest == 2)
        {
            endQuest.SetActive(true);
            middleQuest.SetActive(false);
            currentQuest = 3;
        }
    }

    public void onClickTips()
    {
        tipsUI.SetActive(!tipsUI.activeSelf);
        UpdateTip();
    }

    public void UpdateTip()
    {
        if (currentTip == 1)
        {
            tipsPrevButton.SetActive(false);
            tipsNextButton.SetActive(true);
            tipText.text = "Use WASD or arrow keys to move.";
        } else if (currentTip == 2)
        {
            tipsPrevButton.SetActive(true);
            tipsNextButton.SetActive(true);
            tipText.text = "Stand over an item and use 'E' to pick it up from the ground.";
        } else if (currentTip == 3)
        {
            tipsPrevButton.SetActive(true);
            tipsNextButton.SetActive(true);
            tipText.text = "Click the items button in the bottom right to see what materials you have discovered.";
        } else if (currentTip == 4)
        {
            tipsPrevButton.SetActive(true);
            tipsNextButton.SetActive(true);
            tipText.text = "The number next to each item in your inventory shows you how many you currently have.";
        } else if (currentTip == 5)
        {
            tipsPrevButton.SetActive(true);
            tipsNextButton.SetActive(true);
            tipText.text = "Click the quests button in the top right if you aren't sure what to do next.";
        } else if (currentTip == 6)
        {
            tipsPrevButton.SetActive(true);
            tipsNextButton.SetActive(true);
            tipText.text = "To figure out what ingredients you need for a potion check the recipes tab.";
        } else if (currentTip == 7)
        {
            tipsPrevButton.SetActive(true);
            tipsNextButton.SetActive(false);
            tipText.text = "If you are struggling to find a certain ingredient make sure to check every corner of the map.";
        }
    }
    
    public void onClickPrevTip()
    {
        currentTip -= 1;
        UpdateTip();
    }

    public void onClickNextTip()
    {
        currentTip += 1;
        UpdateTip();
    }

    IEnumerator DisplayMovementHelp()
    {
        yield return new WaitForSeconds(1);

        helpMessageText.text = "Welcome\nTo move:\nWASD / Arrows\nFor help, click tips.";
        helpMessageUI.SetActive(true);
    }
}
