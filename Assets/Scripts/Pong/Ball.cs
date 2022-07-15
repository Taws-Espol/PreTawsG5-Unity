using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public float speed=100f;
    public Rigidbody2D rb;
    public Vector2 startPos;
    [SerializeField] private AudioClip[] ballSounds;
    private AudioSource audioSource;

    [SerializeField] private TMP_Text goal1;
    [SerializeField] private TMP_Text goal2;
    public GameObject player1;
    public GameObject player2;
    int score1 = 0;
    int score2 = 0;

    public int maxScore = 5;

    public bool IAGame;
    void Start(){
        transform.position = startPos;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = ballSounds[0];
        Launch();
    }

    public void Launch(){
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity = new Vector2(x, y) * speed*Time.deltaTime;
    }
    public void Reset(){
        if(!IAGame){
            player2.GetComponent<Players>().Reset();   
        }
        player1.GetComponent<Players>().Reset();
        rb.velocity = Vector2.zero;
        transform.position = startPos;
        Launch();
        
    }

    public void CheckVictory(){
        if(score1 >= maxScore){
            goal1.text = "Win!";
            goal2.text = "Lose!";
            Time.timeScale = 0;
        }
        else if(score2 >= maxScore){
            goal1.text = "Lose!";
            goal2.text = "Win!";
            Time.timeScale = 0;
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        audioSource.clip = ballSounds[0];
        if (other.gameObject.CompareTag("Player")){
            audioSource.Play();
        }
        if (other.gameObject.CompareTag("Finish")){
            if (other.gameObject.name == "Goal1"){
                score1++;
                goal1.text = score1.ToString();
            }
            else{
                score2++;
                goal2.text = score2.ToString();
            }
            audioSource.clip = ballSounds[1];
            audioSource.Play();
            Reset();
            CheckVictory();
        }
    }
}
