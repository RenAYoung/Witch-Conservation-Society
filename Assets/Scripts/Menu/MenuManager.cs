using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{

    WaitForSeconds _delayBetweenCharactersYieldInstruction;

    public TextMeshProUGUI mainTitle;

    public TextMeshProUGUI subTitle;

    public GameObject startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.SetActive(false);

        StartTypeWriterOnText(mainTitle, "The Witch Conservation Society ", 0.1f);

        StartCoroutine(DisplaySubtitle());
    }

    // Update is called once per frame
    void Update()
    {
        
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

    IEnumerator DisplaySubtitle()
    {
        yield return new WaitForSeconds(4);

        StartTypeWriterOnText(subTitle, "Are you ready to start your adventure? ", 0.1f);

        yield return new WaitForSeconds(5);

        startButton.SetActive(true);
    }
}
