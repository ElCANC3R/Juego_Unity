using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        Ladron1Script ladron = other.GetComponent<Ladron1Script>();
        BulletEnemigo bulletEnemigo = other.GetComponent<BulletEnemigo>();

        if (ladron != null)
        {
            ladron.DanoRecibidoLadron1();
            DestroyBullet();
        }
        else if (bulletEnemigo != null)
        {
            bulletEnemigo.DestroyBullet();
            DestroyBullet();
        }
    }
}
