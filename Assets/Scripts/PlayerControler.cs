using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    public float speed = 7;
    public event System.Action OnPlayerDeath;
    public GameObject bulletPrefab;

    float screenHalfWidthInWorldUnits;
    public int bullets;

    void Start()
    {

        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;

        GameObject cubeRightScreen = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeRightScreen.transform.localScale = transform.localScale;
        cubeRightScreen.transform.position = new Vector2(screenHalfWidthInWorldUnits * 2, transform.position.y);
        cubeRightScreen.transform.parent = transform;

        GameObject cubeLeftScreen = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeLeftScreen.transform.localScale = transform.localScale;
        cubeLeftScreen.transform.position = new Vector2(-screenHalfWidthInWorldUnits * 2, transform.position.y);
        cubeLeftScreen.transform.parent = transform;

        



        }

    void Update()
    {


        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenHalfWidthInWorldUnits) {

            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);

            } else if (transform.position.x > screenHalfWidthInWorldUnits) {

            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);

            }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (bullets > 0) {
                Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullets--;
                }
            }


    }

    void OnTriggerEnter2D(Collider2D triggerCollider) {

        if (triggerCollider.tag == "enemy") {
            if (OnPlayerDeath != null) {
                OnPlayerDeath();
                }
            Destroy(gameObject);

            }

    }


}
