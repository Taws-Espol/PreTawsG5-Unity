using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rangeY=3f;
    public float rangeX=7f;
    private Vector3 Movimiento;
    private Animator animator;
    public GameObject Polvo;
    
    public SpriteRenderer sprite;//propiedades del sprite
    public bool invinsible = false;

    public GameObject[] hearts;//Barra de vida
    public int life;

    public Image barraDistancia;//Barra de distancia
    public float barraTiempo=100;
    
    void Start()
    {
        barraDistancia.fillAmount = 0;
        life=hearts.Length;
        animator = GetComponent<Animator>();//para las animaciones
        Polvo=transform.GetChild(0).gameObject;
        sprite = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        Movimiento=new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),0);
        Movimiento=Movimiento.normalized;
        transform.position+=Movimiento*moveSpeed*Time.deltaTime;
        
        if(Input.GetKey("left")){
            animator.speed = 0.1f;//Al retroceder se mueve mas lento
        } 
            
        if(Input.GetKey("right")){
            animator.speed = 1.0f;//Al avanzar se mueve mas rapido
        } 

        if(Input.GetKey("right")==false && Input.GetKey("left")==false){
            animator.speed = 0.4f;
        }
            
        //transform.rotation=Quaternion.Euler(0,0,Input.GetAxis("Vertical")*20);//EL personaje se inclina al moverse
        transform.position= new Vector3(Mathf.Clamp(transform.position.x,-rangeX,rangeX),Mathf.Clamp(transform.position.y,-rangeY,rangeY),0);//limita el movimiento del personaje
    
        if(barraDistancia.fillAmount<1){
            barraDistancia.fillAmount+=Time.deltaTime/barraTiempo;
        }else Debug.Log("Distancia llena");
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Obstacle") && !invinsible) {
            invinsible = true;
            Debug.Log("Obstacle hit");
            sprite.color = Color.red;
            transform.position+=Vector3.left*2;
            life--;
            checkLife();
            Invoke("NormalState",0.5f);

        }

        if (other.collider.CompareTag("Ray")){
            moveSpeed=15;
            Destroy(other.gameObject);
            Invoke("NormalState",2f);
        }
    }

    private void NormalState(){
        sprite.color = Color.white;
        moveSpeed=10;
        invinsible = false;
    }

    public void checkLife(){
        if (life==0){
            //Destroy(hearts[0].gameObject);
            hearts[0].SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if(life==1){
            //Destroy(hearts[1].gameObject);
            hearts[1].SetActive(false);
        }
        else if(life==2){
            hearts[2].SetActive(false);
            //Destroy(hearts[2].gameObject);
        }
    }

}