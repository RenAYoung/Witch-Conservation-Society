using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    public GameObject caveBookPageUI;

    public void OnClickCast()
    {
        caveBookPageUI.SetActive(false);
    }

    public void onClickBye()
    {
        Application.Quit();
    }
}
