using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    public GameObject Daven;
    public GameObject BulletEnemigo;
    private Animator Animator;
    private Rigidbody2D Rigidbody2D;

    //patrol
    public float speed;
    public float distanceP;
    private bool movingRight = true;
    public Transform groundDeteccion;
    //

    private float LastShoot;
    private float tiempo=0f;
    private float Atime=1.3f;
    private int cont;

    public int Vida = 10;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        cont=1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Daven == null)
        {
            return;
        }

        //patrol
        if (Vida>0){
         transform.Translate(Vector2.left * speed *Time.deltaTime);
     RaycastHit2D groundInfo = Physics2D.Raycast(groundDeteccion.position,Vector2.down,distanceP);
     if(groundInfo.collider == false){
         if(movingRight == true){
            transform.eulerAngles = new Vector3(0,-180,0);
            movingRight = false;
         }else{
            transform.eulerAngles = new Vector3(0,0,0);
            movingRight = true; 
         }
     } 
        }
        else{
            transform.Translate(Vector2.left * 0 *Time.deltaTime);
             tiempo += Time.deltaTime;
             if(tiempo > Atime) Muerto();
        }
     //           

        
        Vector3 direction = Daven.transform.position - transform.position;


        float distance = Mathf.Abs(Daven.transform.position.x - transform.position.x);

        if (distance <= 4.0f && Time.time > LastShoot + 0.8f && Vida >0)
        {
            //left
            if(Daven.transform.position.x < transform.position.x && transform.eulerAngles.y == 0)
            {
                Shoot();
                LastShoot = Time.time;
            }
            //right
            if(Daven.transform.position.x > transform.position.x && transform.eulerAngles.y == 180)
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
        if(Vida<0 && cont==1){
            cont=0;
            Animacion();
        }     
    }

    public void MatarInstaEspecial()
    {
           Vida -= 5;
        if(Vida<0 && cont==1){
            cont=0;
            Animacion();
        }    
    }

    public void Animacion(){
            //GetComponent<Collider2D>().enabled = false;
            Animator.SetTrigger("Death");               
    }

    public void Muerto(){
        
         Destroy(gameObject);
    }
}
