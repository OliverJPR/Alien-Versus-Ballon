using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    private float moveSpeed = 20;
    private Rigidbody2D rb2d;
  
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(-moveSpeed, 0f);
    }
}
