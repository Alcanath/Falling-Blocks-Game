using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingCubePrefab;

    Vector2 screenHalfSizeWorldUnits;
    public float spawnAngle;
    public Vector2 spawnSizeMinMax;
    float nextSpawnTime;

    public float difficultyRate;
    public float spawnRate = 1;
    public float speed = 7;
    float difficultWait;
    int difficultyLvl = 1;




    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);

        printDifficulty();
        }



    // Update is called once per frame
    void Update()
    {



        if (Time.time > nextSpawnTime) {
            nextSpawnTime = Time.time + spawnRate;

            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            float rotation = Random.Range(-spawnAngle, spawnAngle);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
            GameObject newBlock = (GameObject)Instantiate(fallingCubePrefab, spawnPosition, Quaternion.Euler(Vector3.forward * rotation));
            
            newBlock.transform.localScale = Vector3.one * spawnSize;
            }



        
        if (Time.timeSinceLevelLoad > difficultWait) {
            difficultWait = Time.timeSinceLevelLoad + difficultyRate;
            if (difficultyLvl < 20) {
                difficultyLvl++;
                spawnRate -= .04f;
                speed += .425f;
                printDifficulty();
                }
        }
        



     }

    void printDifficulty() {
        print(spawnRate + " - spawnRate");
        print(difficultyLvl + " - difficulty lvl");
        print(speed + " - speed");

        }
    }
