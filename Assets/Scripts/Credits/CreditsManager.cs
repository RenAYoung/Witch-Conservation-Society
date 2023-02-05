using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreditsManager : MonoBehaviour
{
    int currentCredits = 1;
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;
    public GameObject prevCreditsButton;
    public GameObject nextCreditsButton;

    public GameObject returnButton;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCredits();
    }

    public void UpdateCredits()
    {
        if (currentCredits == 1)
        {
            prevCreditsButton.SetActive(false);
            nextCreditsButton.SetActive(true);
            leftText.text = "II = Itch.io\nUAS = Unity Asset Store\n-II - 9E0 - Witches Pack: Witch\n-UAS - Cainos - Pixel Art Top Down Basic: Green grass, broken ground tiles, smooth ground stone, cavern building, outside cavern rocks, cavern props, light green trees, light green bushes, light green grass, bridge stone props, wooden signs ";
            rightText.text = "-II - rowdy41 - Edinnu Small Forest: brown dirt\n-II - Elthen's Pixel Art Shops - 2D Pixel Art Dungeon Tileset: broken ground stone, dark green trees, dark green bushes, stumps\n-II - Gif - Free RPG Asset Tileset Interior Pack (Super Retro World): bridge billboard, map border\n-II - shubibubi - Cozy Farm Asset Pack: house, larkspur";
        } else if (currentCredits == 2)
        {
            prevCreditsButton.SetActive(true);
            nextCreditsButton.SetActive(true);
            leftText.text = "II = Itch.io\nUAS = Unity Asset Store\n-II - shubibubi - 100 Nature Things: brown mushroom, leaf, acorn, dandelion\n-II - SciGho - Fruit+: dragonfruit, banana, red apple, pear, yellow apple, eggplant, yellow bell pepper, blueberry\n-II - Pop Shop Packs - Wild Plants Pixel Asset Pack: kidney bean, walnut";
            rightText.text = "-II - o_lobster - Simple Dungeon Crawler 16x16 Pixel Art Asset Pack: cave door\n-II - VectorPixelStar - Food and little bit of kitchenware: onion\n-II - Mounir Tohami - Pixel Art UI Elements: GUI beige block, dark brown board, dark blue square\n-UAS - SiLena_ART - 2D Handcrafted Potions and Flowers Art Pack: large potion images";
        } else if (currentCredits == 3)
        {
            prevCreditsButton.SetActive(true);
            nextCreditsButton.SetActive(true);
            leftText.text = "II = Itch.io\nUAS = Unity Asset Store\n-UAS - Digital Moons - Pixel Skies Demo Background Pack: starry backgrounds\n-II - Foxel Indie Dev - Pixel Art Book: book sprites\n-II - Pixel_Poem - 2D Pixel Dungeon Asset Pack: purple puzzle blocks";
            rightText.text = "-II - brullov - Fire Animation Pixel Art FX Sprites: puzzle fire\n-UAS - Beaver Sound - Romantic Cine Jazz Piano Vol 1: Overflowing Memories menu & end music, How Are You intro letter music\n-UAS - Nox_Sound - Nature-Essentials:  Cave Drips Loop main game music";
        } else if (currentCredits == 4)
        {
            prevCreditsButton.SetActive(true);
            nextCreditsButton.SetActive(true);
            leftText.text = "II = Itch.io\nUAS = Unity Asset Store\n-UAS - Pablo Wunderlich - Complete Mysterious Forest Game Music Pack: Splash Screen puzzle music\n-Fontspace - Rick Mueller - Dragonfly Font: font\n-Pixabay - ScratchnSniff - Pop or bloop: object pickup sound effect";
            rightText.text = "-Pixabay - Zeinel - Flipping Through a Book mp3: page glip sound effect\n-Pixabay - ShidenBeatsMusic - Sounds Effect Twinkle/Sparkle: potion crafted sound effect";
        } else if (currentCredits == 5)
        {
            prevCreditsButton.SetActive(true);
            nextCreditsButton.SetActive(false);
            leftText.text = "Code Sources:\n-https://stackoverflow.com/questions/66337331/implement-stacking-to-my-inventory-system-in-unity\n-https://www.youtube.com/watch?v=sPBhDcuBuIA&list=PL-hj540P5Q1hLK7NS5fTSNYoNJpPWSL24&index=1";
            rightText.text = "-https://stackoverflow.com/questions/62650680/delayed-text-display-in-unity\n-https://www.youtube.com/watch?v=cLzG1HDcM4s";
        }
        
    }

    public void OnClickPrevCredits()
    {
        currentCredits -= 1;
        UpdateCredits();
    }

    public void onClickNextCredits()
    {
        currentCredits += 1;
        UpdateCredits();
    }
}
