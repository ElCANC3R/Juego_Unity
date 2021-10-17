using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public float speed;
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        Rigidbody2D.velocity = Vector3.right*speed;
    }
}
