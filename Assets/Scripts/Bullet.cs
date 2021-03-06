using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y > (Camera.main.orthographicSize + transform.localScale.y)) {
            Destroy(gameObject);

            //print(Camera.main.orthographicSize);
            }

        }

    void OnTriggerEnter2D(Collider2D triggerCollider) {

        if (triggerCollider.tag == "enemy") {
            Destroy(triggerCollider.gameObject);
            Destroy(gameObject);

            }
        }
    }
