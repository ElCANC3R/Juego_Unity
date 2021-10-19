using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladron1Script : MonoBehaviour
{
    public GameObject Daven;
    public GameObject BulletEnemigo;

    private float LastShoot;

    public int Vida = 5;


    // Update is called once per frame
    void Update()
    {
        if (Daven == null)
        {
            return;
        }

        Vector3 direction = Daven.transform.position - transform.position;

        if (direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(-0.3f, 0.3f, 1.0f);
        }


        float distance = Mathf.Abs(Daven.transform.position.x - transform.position.x);

        if (distance <= 4.0f && Time.time > LastShoot + 0.8f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 0.3f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletEnemigo, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletEnemigo>().SetDirection(direction);
    }

    public void DanoRecibidoLadron1()
    {
        Vida -= 1;
        if (Vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void MatarInstaEspecial()
    {
        Destroy(gameObject);
    }

}