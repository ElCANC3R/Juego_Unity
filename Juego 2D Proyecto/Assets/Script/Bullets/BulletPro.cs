using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPro : MonoBehaviour
{
    
    private Rigidbody2D Rigidbody2D;
    public float speed;
    private Vector2 Direction;

    private int enemigos = 2;
    
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
        Enemigo2 enemigo = other.GetComponent<Enemigo2>();
        BulletEnemigo bulletEnemigo = other.GetComponent<BulletEnemigo>();

        if (ladron != null)
        {
            ladron.MatarInstaEspecial();
            enemigos--;
            if (enemigos == 0)
            {
                DestroyBullet();
            }
        }
        else if (bulletEnemigo != null)
        {
            bulletEnemigo.DestroyBullet();
        }
        else if(enemigo != null){
             enemigo.MatarInstaEspecial();
             DestroyBullet();
        }
    }
}
