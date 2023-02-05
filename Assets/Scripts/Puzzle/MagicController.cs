using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MagicController : MonoBehaviour
{

    public float speed = 3;

    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        if (Mathf.Abs(xAxis) == 0 && Mathf.Abs(yAxis) == 0) {
            body.velocity = new Vector2(0,0);
        }
        else if (Mathf.Abs(xAxis) > Mathf.Abs(yAxis)) {
            if (xAxis < 0) {
                speed = -1 * (Mathf.Abs(speed));
            }
            else {
                speed = Mathf.Abs(speed);
            }
            body.velocity = new Vector2(speed,0);
        }
        else if (Mathf.Abs(xAxis) < Mathf.Abs(yAxis)) {
            if (yAxis < 0) {
                speed = -1 * (Mathf.Abs(speed));
            }
            else {
                speed = Mathf.Abs(speed);
            }
            body.velocity = new Vector2(0,speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // got to end of maze
        LoadScene("End");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
