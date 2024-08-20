using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] Image loseScreen;
    [SerializeField] GameObject bg1;
    [SerializeField] GameObject bg2;
    [SerializeField] float backgroundSpeed = -1.5f;
    [SerializeField] GameObject Block;
    [SerializeField] int blockNum;
    GameObject[] blocks; 
    Rigidbody2D rb1;
    Rigidbody2D rb2;
    float Lengthh = 0f;
    float turnTime = 0f;
    int counting = 0;
    void Start()
    {
        rb1 = bg1.GetComponent<Rigidbody2D>();
        rb2 = bg2.GetComponent<Rigidbody2D>();
        rb1.velocity = new Vector2(backgroundSpeed, 0);
        rb2.velocity = new Vector2(backgroundSpeed, 0);
        Lengthh = bg1.GetComponent<BoxCollider2D>().size.x;

        blocks = new GameObject[blockNum];
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i] = Instantiate(Block, new Vector2(-20, -20), Quaternion.identity);
            Rigidbody2D blocksRb = blocks[i].AddComponent<Rigidbody2D>();
            blocksRb.gravityScale = 0;
            blocksRb.velocity = new Vector2(backgroundSpeed, 0);
        }
    }

    void Update()
    {
        if(bg1.transform.position.x <= -Lengthh)
        {
            bg1.transform.position += new Vector3(Lengthh * 2, 0);
        }
        if (bg2.transform.position.x <= -Lengthh)
        {
            bg2.transform.position += new Vector3(Lengthh * 2, 0);
        }
        //------------------------------------------------------------

        turnTime += Time.deltaTime;
        if (turnTime > 3.5f)
        {
            turnTime = 0f;
            float yIndex = Random.Range(1.60f, 3.45f);
            blocks[counting].transform.position = new Vector3(13, yIndex);
            counting++;
            if (counting >= blocks.Length)
            {
                counting = 0;
            }
        }
    }
    public void GameOver()
    {
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        rb1.velocity = Vector2.zero;
        rb2.velocity = Vector2.zero;
        loseScreen.gameObject.SetActive(true);
        StartCoroutine("LoadCurrentScene");
    }
    IEnumerator LoadCurrentScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
