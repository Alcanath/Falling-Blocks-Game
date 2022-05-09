using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour {
    //public float speed = 7;

    Vector2 screenHalfSizeWorldUnits;

    Spawner spawner;


    void start() {

        //spawner = FindObjectOfType<Spawner>();



        }


    void Update() {
        spawner = FindObjectOfType<Spawner>();

        transform.Translate(Vector3.down * spawner.speed * Time.deltaTime);

        if (transform.position.y < -(Camera.main.orthographicSize + transform.localScale.y)) {
            Destroy(gameObject);

            //print(Camera.main.orthographicSize);
            }


        }

    }
