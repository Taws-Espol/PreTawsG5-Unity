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

    [SerializeField] private TMP_Text goalLeft;
    [SerializeField] private TMP_Text goalRight;
    public GameObject playerLeft;
    public GameObject playerRight;
    int scoreLeft = 0;
    int scoreRight = 0;

    public bool infiniteMode=false;
    [SerializeField] private TMP_Text timer;
    private float timeText=0f;
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
            playerRight.GetComponent<Players>().Reset();   
        }
        playerLeft.GetComponent<Players>().Reset();
        rb.velocity = Vector2.zero;
        transform.position = startPos;
        Launch();
        
    }

    public void CheckVictory(){
        if(scoreLeft >= maxScore){
            goalLeft.text = "Win!";
            goalRight.text = "Lose!";
            Time.timeScale = 0;
        }
        else if(scoreRight >= maxScore){
            goalLeft.text = "Lose!";
            goalRight.text = "Win!";
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
            if (other.gameObject.name != "GoalLeft"){
                scoreLeft++;
                goalLeft.text = scoreLeft.ToString();
            }
            else{
                scoreRight++;
                goalRight.text = scoreRight.ToString();
            }
            audioSource.clip = ballSounds[1];
            audioSource.Play();
            Reset();
            if(!infiniteMode){
                CheckVictory();
            }
        }
    }

    public void Update(){
        if(infiniteMode){
            timeText += Time.deltaTime;
            timer.text = timeText.ToString("f0");
        }
        if(timeText >= 60f){
            timeText = 0f;
            Reset();
            if(scoreLeft >= maxScore){
                goalLeft.text = "Win!";
                goalRight.text = "Lose!";
                Time.timeScale = 0;
            }
            else if(scoreRight >= maxScore){
                goalLeft.text = "Lose!";
                goalRight.text = "Win!";
                Time.timeScale = 0;
            }
        }
    }
}
