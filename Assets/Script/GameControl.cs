using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;            //A reference to our game control script so we can access it statically.
    public Text scoreText;                        //A reference to the UI text component that displays the player's score.
    public GameObject gameOvertext;                //A reference to the object that displays the text which appears when the player dies.

    private float spawnTime = 0.5f;
    // public GameObject humanGirl;                   // A reference to the girl
    // public GameObject humanBoy;                   // A reference to the boy
    public Camera cam;

    public int score = 0;                        //The player's score.
    public bool gameOver = false;                //Is the game over?
    public float scrollSpeed = -3.5f;

    public GameObject humanPrefab;
    public GameObject opt1;
    public GameObject opt2;
    private int spawnx;
    public int cnt;
    private int level = 0;
    private float spawnRate = 3f;

    /*audio
    1 = jump
    2 = slash
    0 = otherwise
    */
    public int girlBehave = 0;


    void Awake()
    {   
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Update()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(gameOver == false){
            if(score % 5==0 && score != 0)
            {
                level++;
                spawnRate = 3f + score*0.006f;
                scrollSpeed = -3.5f - score*0.001f;
                spawnTime = 0.0f;
            }
            spawnTime += Time.deltaTime;
            if (spawnTime >= spawnRate)
            {
                // Waktu Spawn 
                // Log
                // Debug.Log("Spawn Object" + Time.deltaTime.ToString());
                // Fugsi Spawn
                cnt = 1;
                if(cnt % 2 == 0){
                    humanPrefab = opt1;
                    spawnx = 30;
                }
                else{
                    humanPrefab = opt2;
                    spawnx = 1;
                }
                Spawn();
            }

            // Debug.Log("Time in game : " + Time.deltaTime.ToString());
        }
    }

    public void GirlScored()
    {
        //The bird can't score if the game is over.
        if (gameOver)
            return;
        //If the game is not over, increase the score...
        score++;
        //...and adjust the score text.
        scoreText.text = "Score: " + score.ToString();
    }

    public void GirlDied()
    {
        gameOvertext.SetActive(true);
        gameOver = true;
    }

    void Spawn()
    {
        // Buat Vector posisi Spawn
        Vector2 spawnPos = new Vector2(cam.gameObject.transform.position.x + spawnx, 0.07f);
        Instantiate(humanPrefab, spawnPos, Quaternion.identity);
        // Debug.Log(spawnPos+" "+spawnTime);
        spawnTime = 0f;
    }
}
