using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float speed = 3;
    public float speedX, speedY = 0;

    private Rigidbody2D body;

    public bool isMoving = false;

    // the player's annotation for the sprite
    private Animator animator;

    private SpriteRenderer renderer; 

    public LayerMask movementMask;

    public GameObject helpMessageUI;
    public TextMeshProUGUI helpMessageText;

    Camera cam;

    public GameManager gm;
        
    public GameObject pickupText;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        
        pickupText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        // setting up annotations to actually change as player moves
        animator.SetBool("isMoving", isMoving);

        if (Mathf.Abs(xAxis) == 0 && Mathf.Abs(yAxis) == 0) {
            isMoving = false;
            body.velocity = new Vector2(0,0);
            speedX = 0;
            speedY = 0;
        }
        else 
        {            
            isMoving = true;
            if (xAxis < 0 && Mathf.Abs(xAxis) != 0) {
                speedX = -1 * (Mathf.Abs(speed));
                renderer.flipX = true;
            }
            else if (xAxis > 0 && Mathf.Abs(xAxis) != 0) {
                speedX = Mathf.Abs(speed);
                renderer.flipX = false;
            }
            if (yAxis < 0 && Mathf.Abs(yAxis) != 0) {
                speedY = -1 * (Mathf.Abs(speed));
            }
            else if (yAxis > 0 && Mathf.Abs(yAxis) != 0) {
                speedY = Mathf.Abs(speed);
            } 
            if (Mathf.Abs(xAxis) == 0) {
                speedX = 0;
            }
            if (Mathf.Abs(yAxis) == 0) {
                speedY = 0;
            }
            body.velocity = new Vector2(speedX,speedY);
                
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cave")
        {
            // got to end of maze
            LoadScene("Puzzle");
        }
        if (other.gameObject.tag == "LockedDoor")
        {
            if (gm.dissolveMetalCrafted)
            {
                gm.endQuestDone = true;
                gm.OnClickOpenPuzzle();
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ForestBorder")
        {
            helpMessageUI.SetActive(true);
            helpMessageText.text = "You are unable to enter the dark forest yet. You must first find a way to see in the dark. Maybe look through your recipes for help.";
        }
        if (other.gameObject.tag == "CaveSign")
        {
            helpMessageUI.SetActive(true);
            helpMessageText.text = "NorthEast\n-->\nQuarry";
        }
        if (other.gameObject.tag == "GladeSign")
        {
            helpMessageUI.SetActive(true);
            helpMessageText.text = "SouthEast\n-->\nCalm Glade";
        }
        if (other.gameObject.tag == "ForestSign")
        {
            helpMessageUI.SetActive(true);
            helpMessageText.text = "West\n<--\nDark Forest";
        }
        if (other.gameObject.tag == "BridgeSign")
        {
            helpMessageUI.SetActive(true);
            helpMessageText.text = "West\n<--\nMoonlight City";
        }
        if (other.gameObject.tag == "Billboard")
        {
            helpMessageUI.SetActive(true);
            helpMessageText.text = "The path to Moonlight City is temporarily closed in order to protect the town's population.";
        }
        if (other.gameObject.tag == "LockedDoor")
        {
            helpMessageUI.SetActive(true);
            helpMessageText.text = "You are unable to enter the cavern yet. You must first find a way to remove the metal lock. Maybe look through your recipes for help.";
        }

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    
}
