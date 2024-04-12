using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    private float moveSpeed = 5;
    private float timer = 0;
    private float changeDirectionTime = 2;

    // Update is called once per frame
    void Start()
    {

    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= changeDirectionTime)
        {
            ChangeDirection();
            timer = 0;
        }

        Vector3 movement = new Vector3(0f, moveSpeed, 0f);
        transform.Translate(movement * Time.deltaTime);
    }

    void ChangeDirection()
    {
        float randomDirection = Random.Range(-2f, -2f);
        moveSpeed = Random.Range(3f, 7f);

        if (randomDirection < 0)
        {
            transform.Rotate(0, 0, 90); 
        }
        else
        {
            transform.Rotate(0, 0, -90);
        }
    }
}