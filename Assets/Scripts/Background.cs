using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    Vector3 screenHalfSizeWorldUnits = new Vector3();
    // Start is called before the first frame update
    void Start()
    {

        screenHalfSizeWorldUnits = new Vector3(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize, 1);
        transform.localScale = screenHalfSizeWorldUnits * 2;
        Vector3 startPos = new Vector3(0, 0, 5);
        transform.position = startPos;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
