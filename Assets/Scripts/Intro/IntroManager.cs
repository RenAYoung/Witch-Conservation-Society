using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{

    public GameObject noteBookFrontUI;
    public GameObject noteBookInteriorUI;

    public AudioSource flipPageAudio;

    // Start is called before the first frame update
    void Start()
    {
        noteBookFrontUI.SetActive(true);
        noteBookInteriorUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickOpenNotebook()
    {

        flipPageAudio.Play(0);
        noteBookFrontUI.SetActive(false);
        noteBookInteriorUI.SetActive(true);


    }



}
