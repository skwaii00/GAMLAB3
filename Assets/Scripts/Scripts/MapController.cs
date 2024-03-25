using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MapBoundary"))
        {
            transform.position = new Vector2(0, 0);
        }
    }
}