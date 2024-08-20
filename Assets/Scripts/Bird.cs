using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bird : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float jumpingRate = 250f;
    [SerializeField] TextMeshProUGUI scoreText;
    int puan = 0;
    bool gameOver = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameOver == false)
        {
            rb.velocity = new Vector2(0f, 0f);
            rb.AddForce(new Vector2(0f, jumpingRate));
        }
        if(rb.velocity.y > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 10);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, -10);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Point")
        {
            puan++;
            scoreText.text = puan.ToString();
        }
        if(collision.gameObject.tag == "Block")
        {
            gameOver = true;
            FindObjectOfType<GameController>().GameOver();
        }
    }
}
