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

    public Transform Hitbox;
    private bool attack;

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
            if(attack == true){
                transform.Translate(Vector2.left * 0 *Time.deltaTime);
            }else{
                transform.Translate(Vector2.left * speed *Time.deltaTime);
            }
            
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

    }

    private void OnTriggerEnter2D(Collider2D other) {
        //Attack
        DeivenMove Daven = other.GetComponent<DeivenMove>();
        if (Daven != null && Vida >0)
        {
            Animator.SetBool("Attack", true);
            if (Time.time > LastShoot + 0.4f){
                Daven.DanoRecibido();
                LastShoot = Time.time;
            }
            attack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        //Attack
        DeivenMove Daven = other.GetComponent<DeivenMove>();
        if (Daven != null && Vida >0)
        {
            Animator.SetBool("Attack", false);
            attack = false;
        }
    }

    public void DanoRecibidoLadron1()
    {
        Vida -= 1;
        if(Vida<=0 && cont==1){
            cont=0;
            Animacion();
            gameObject.GetComponent<GanasteKalan>().restar();
        }     
    }

    public void MatarInstaEspecial()
    {
        Vida -= 5;
        if(Vida<=0 && cont==1){
            cont=0;
            Animacion();
            gameObject.GetComponent<GanasteKalan>().restar();
        }    
    }

    public void Animacion(){
        //GetComponent<Collider2D>().enabled = false;
        Animator.SetTrigger("Death");               
    }

    public void Muerto(){
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        DeivenMove Daven = other.collider.GetComponent<DeivenMove>();
        if (Daven != null && Vida >0)
        {
            Animator.SetBool("Attack", true);
            if (Time.time > LastShoot + 0.4f){
                Daven.DanoRecibido2();
                LastShoot = Time.time;
            }
            attack = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        DeivenMove Daven = other.collider.GetComponent<DeivenMove>();
        if (Daven != null && Vida >0)
        {
            Animator.SetBool("Attack", false);
            attack = false;
        }
    }
}
