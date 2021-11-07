using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
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

    public void SetKALAN(){
        transform.localScale = new Vector3(-0.5734f, 0.5734f, 0.5734f);
    }

    public void DestroyBullet(){
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Ladron1Script ladron = other.GetComponent<Ladron1Script>();
        Enemigo2 enemigo = other.GetComponent<Enemigo2>();
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
        else if (enemigo != null){
            enemigo.DanoRecibidoLadron1();
            DestroyBullet();
        }
    }
}
