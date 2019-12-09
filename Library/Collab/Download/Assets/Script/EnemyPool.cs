using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public int humanPoolSize = 5;
    public GameObject humanPrefab;
    public GameObject opt1;
    public GameObject opt2;

    public float spawnRate = 4f;
    public float humanMin = -1f;
    public float humanMax = 3.5f;

    public GameObject[] humans;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawn;
    private float spawnXPos = 30f;
    private int currentObj = 0;
    private int rng;

    // Start is called before the first frame update
    void Start()
    {
        humans = new GameObject[humanPoolSize];
        for(int i=0; i < humanPoolSize; i++){
            rng = Random.Range(0,i);
            if(rng % 2 == 0){
                humanPrefab = opt1;
                objectPoolPosition = new Vector2(-15f, -25f);
            }
            else
            {
                humanPrefab = opt2;
                objectPoolPosition = new Vector2(-15f, 0.5f);
            }
            humans[i] = (GameObject)Instantiate(humanPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if(GameControl.instance.gameOver == false && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0f;
            humans[currentObj].transform.position = new Vector2(spawnXPos, 0f);
            currentObj++;

            if(currentObj >= humanPoolSize)
            {
                currentObj = 0;
            }
        }
    }
}
