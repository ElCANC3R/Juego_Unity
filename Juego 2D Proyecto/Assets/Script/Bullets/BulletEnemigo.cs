using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemigo : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public float speed;
    private Vector2 Direction;
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        Rigidbody2D.velocity=Direction*speed;
    }
    public void SetDirection(Vector2 direction){
        Direction = direction;
    }

    public void DestroyBullet(){
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DeivenMove Daven = other.GetComponent<DeivenMove>();

        if (Daven != null)
        {
            Daven.DanoRecibido();
            DestroyBullet();
        }
    }
}
