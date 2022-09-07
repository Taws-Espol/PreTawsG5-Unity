using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Ball : MonoBehaviour
{
    public float speed=360;
    public Rigidbody2D rb;
    public Vector2 startPos;
    [SerializeField] private AudioClip[] ballSounds;
    private AudioSource audioSource;

    public GameObject panel;
    [SerializeField] private TMP_Text puntos;
    [SerializeField] private TMP_Text BestScore;

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
        panel.SetActive(false);
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity = new Vector2(x, y) * speed*Time.deltaTime*2;
    }
    public void Reset(){
        if(!IAGame){
            playerRight.GetComponent<Players>().Reset();
            Launch();   
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
            }else{
                if(scoreRight>=1){
                    goalLeft.text = scoreLeft.ToString();
                    goalRight.text = "End";
                    Time.timeScale = 0;
                    panel.SetActive(true);
                    puntos.text = "Score: " + scoreLeft.ToString();
                    

                    if(scoreLeft > GameManager.instance.bestPointsPong){
                        GameManager.instance.bestPointsPong = scoreLeft;
                        GameManager.instance.bestNombrePong = "anonymous";
                        GameManager.instance.SaveScorePong();
                        
                    }
                    BestScore.text = $"Best Score: {GameManager.instance.bestPointsPong} - {GameManager.instance.bestNombrePong}";
                }
            }
        }
    }

    public void Update(){
        if(infiniteMode){
            timeText += Time.deltaTime;
            timer.text = timeText.ToString("f0");
        }
    }

    public void btnJugar(){
        Time.timeScale = 1;
        goalRight.text = "0";
        goalLeft.text = "0";
        scoreLeft = 0;
        scoreRight = 0;
        timeText = 0;
        Reset();
    }

}
