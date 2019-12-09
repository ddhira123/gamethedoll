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

    // /* Spawner */
    // private float delaySpawn = 0.0005f;
    // private float spawnTime = 0.0f;
    // public GameObject humanGirl;                   // A reference to the girl
    // public GameObject humanBoy;                   // A reference to the boy
    // public Camera cam;

    public int score = 0;                        //The player's score.
    public bool gameOver = false;                //Is the game over?
    public float scrollSpeed = -1.5f;


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

        // if (spawnTime < Time.deltaTime)
        // {
        //     // Waktu Spawn 
        //     spawnTime = Time.deltaTime + delaySpawn;

        //     // Log
        //     Debug.Log("Spawn Girl Object" + Time.deltaTime.ToString());
        //     // Fugsi Spawn
        //     int spTime = (int)(spawnTime);
        //     if(spTime % 2 == 0)
        //         SpawnGirl();
        //     else
        //         SpawnBoy();
        // }

        // Debug.Log("Time in game : " + Time.deltaTime.ToString());

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

    // void SpawnGirl()
    // {
    //     // Buat Vector posisi Spawn
    //     Vector3 girlPos = new Vector3(cam.gameObject.transform.position.x + 10.0f, -1.5f, 0.0f);

    //     // Initiate Object supaya keluar di game
    //     Instantiate(humanGirl, girlPos, Quaternion.identity);
    // }

    // void SpawnBoy()
    // {
    //     // Buat Vector posisi Spawn
    //     Vector3 boyPos = new Vector3(cam.gameObject.transform.position.x + 10.0f, -1.5f, 0.0f);

    //     // Initiate Object supaya keluar di game
    //     Instantiate(humanBoy, boyPos, Quaternion.identity);
    // }
}
