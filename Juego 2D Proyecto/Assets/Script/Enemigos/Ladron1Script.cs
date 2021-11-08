using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladron1Script : MonoBehaviour
{
    public GameObject Daven;
    public GameObject BulletEnemigo;
    public GameObject Morado;
    public GameObject Cyan;
    public GameObject Verde;
    public GameObject Rojo;

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

        /*if (direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(-0.3f, 0.3f, 1.0f);
        }*/


        float distance = Mathf.Abs(Daven.transform.position.x - transform.position.x);

        if (distance <= 4.0f && Time.time > LastShoot + 0.8f)
        {
            //left
            if (Daven.transform.position.x < transform.position.x && transform.eulerAngles.y == 0)
            {
                Shoot();
                LastShoot = Time.time;
            }
            //right
            if (Daven.transform.position.x > transform.position.x && transform.eulerAngles.y == 180)
            {
                Shoot();
                LastShoot = Time.time;
            }
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        //Rotation
        if (transform.eulerAngles.y == 180) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletEnemigo, transform.position + direction * 0.3f, Quaternion.identity);
        bullet.GetComponent<BulletEnemigo>().SetDirection(direction);
    }

    public void DanoRecibidoLadron1()
    {
        Vida -= 1;
        if (Vida <= 0)
        {
            GameObject este = gameObject;
            if (este.GetComponent<PasoPrimerNivelKLN>() != null)
            {
                este.GetComponent<PasoPrimerNivelKLN>().restar();
            }
            Alea();
            Destroy(gameObject);
        }
    }

    public void MatarInstaEspecial()
    {
        GameObject este = gameObject;
        if (este.GetComponent<PasoPrimerNivelKLN>() != null)
        {
            este.GetComponent<PasoPrimerNivelKLN>().restar();
        }
        Alea();
        Destroy(gameObject);
    }

    public void Alea()
    {
        if (Random.Range(1, 11) == 1)
        {
            switch (Random.Range(1, 5))
            {
                case 1:
                    GameObject BuffMorado = Instantiate(Morado, transform.position + Vector3.down * 0.5f, Quaternion.identity);
                    break;
                case 2:
                    GameObject BuffCyan = Instantiate(Cyan, transform.position + Vector3.down * 0.5f, Quaternion.identity);
                    break;
                case 3:
                    GameObject BuffVerde = Instantiate(Verde, transform.position + Vector3.down * 0.5f, Quaternion.identity);
                    break;
                case 4:
                    GameObject BuffRojo = Instantiate(Rojo, transform.position + Vector3.down * 0.5f, Quaternion.identity);
                    break;
            }
        }
    }

}