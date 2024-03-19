using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    private float direction = 1;
    private float moveSpeed = 3;

    // Update is called once per frame
    void Start()
    {
        
    }
    void Update()
    {
        Vector3 movement = new Vector3(0f, direction, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        if (transform.position.y >= 1.44f || transform.position.y <= -1.67f)
        {
            direction *= -1;
        }
    }
}
