using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Valores Configurables")]
    private float moveSpeed = 10f;
    private float animatorSpeed = 1f;
    private float limArriba = 3.6f;
    private float limAbajo = -3.4f;
    private float limIzquierda = -8f;
    private float limDerecha = 7f;

    private Animator animator;
    public GameObject polvo;
    
    public SpriteRenderer sprite;
    public bool invincible = false;

    [SerializeField] private AudioClip CoinSound;
    [SerializeField] private AudioClip RaySound;
    private AudioSource audioSource;
    [SerializeField] private GameObject Audio;

    [Header("Barra de Vida")]
    [SerializeField] private GameObject barraVida;
    [SerializeField] private Sprite[] vidas;
    [SerializeField] public int salud = 2;

    [Header("Items")]
    //[SerializeField] private int conteoRayos = 0;
    [SerializeField] public Text textoMoneda;
    [SerializeField] private int conteoMonedas = 0;

    void Start()
    {
        Time.timeScale = 1;
        audioSource = Audio.GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        polvo = transform.GetChild(0).gameObject;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 movimiento = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),0);
        movimiento = movimiento.normalized;
        transform.position += movimiento * moveSpeed * Time.deltaTime;

        animator.speed = animatorSpeed;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.speed = 0.1f;
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            animator.speed = 1.0f;
        }
        float posX = Mathf.Clamp(transform.position.x, limIzquierda, limDerecha);
        float posY = Mathf.Clamp(transform.position.y, limAbajo, limArriba);
        transform.position = new Vector3(posX, posY, 0);

        if(Time.timeScale >= 1)
        {
            float aumento = 0.02f * Time.deltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale + aumento, 0, 2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.collider.CompareTag("Obstacle") && !invincible) 
        {
            invincible = true;
            sprite.color = Color.red;
            transform.position += Vector3.left;
            Invoke("NormalState", 0.5f);
            ActualizarVida(--salud);
        }

        if (other.collider.CompareTag("Ray"))
        {
            audioSource.PlayOneShot(RaySound);
            moveSpeed = 18;
            sprite.color = Color.cyan;
            Invoke("NormalState", 3f);
        }

        if (other.collider.CompareTag("Coin"))
        {
            audioSource.PlayOneShot(CoinSound);
            ActualizarConteoMoneda(++conteoMonedas);
        }
    }

    private void NormalState()
    {
        sprite.color = Color.white;
        moveSpeed = 10;
        animatorSpeed = 10;
        invincible = false;
    }

    private void ActualizarVida(int salud)
    {
        barraVida.GetComponent<Image>().sprite = vidas[salud];
        if (salud == 0)
        {
            moveSpeed = 0;
            animatorSpeed = 0f;
            GetComponent<Collider2D>().enabled = false;
            Invoke("RecargarNivel", 1f);
        }
    }

    private void ActualizarConteoMoneda(int monedas)
    {
        textoMoneda.GetComponent<Text>().text = "X" + monedas;
    }

    private void RecargarNivel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}