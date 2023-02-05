using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndManager : MonoBehaviour
{

    WaitForSeconds _delayBetweenCharactersYieldInstruction;

    public TextMeshProUGUI endTitle;

    public GameObject endButton;

    public GameObject creditsButton;

    // Start is called before the first frame update
    void Start()
    {
        endButton.SetActive(false);
        creditsButton.SetActive(false);

        StartTypeWriterOnText(endTitle, "THE END\nThanks for playing! ", 0.1f);

        StartCoroutine(DisplayByeButton());

    }

    public void StartTypeWriterOnText(TextMeshProUGUI textComponent, string stringToDisplay, float delayBetweenCharacters = 0.2f)
    {
        StartCoroutine(TypeWriterCoroutine(textComponent, stringToDisplay,  delayBetweenCharacters));
    }
    
    IEnumerator TypeWriterCoroutine(TextMeshProUGUI textComponent, string stringToDisplay, float delayBetweenCharacters)
    {
        // Cache the yield instruction for GC optimization
        _delayBetweenCharactersYieldInstruction = new WaitForSeconds(delayBetweenCharacters);
        // Iterating(looping) through the string's characters
        for(int i = 0; i < stringToDisplay.Length; i++)
        {
            // Retrieves part of the text from string[0] to string[i]
            textComponent.text = stringToDisplay.Substring(0, i);
            // We wait x seconds between characters before displaying them
            yield return _delayBetweenCharactersYieldInstruction;
        }
    }

    IEnumerator DisplayByeButton()
    {

        yield return new WaitForSeconds(4);
        creditsButton.SetActive(true);
        endButton.SetActive(true);

    }
}
