using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerArkanoid : MonoBehaviour
{
    public int lives =3;
    public GameObject  panel_Fin_del_juego;
    public TextMeshProUGUI txt_Puntaje;

    void Start()
    {
        panel_Fin_del_juego.SetActive(false);

    }

    public void LoseHealth(){
        lives--;
        if(lives <= 0){
            panel_Fin_del_juego.SetActive(true);

            txt_Puntaje.text = "400"+ " pts";
            Time.timeScale = 0;
        }
        else{
            ResetLevel();
        }
    }

    public void ResetLevel(){
        FindObjectOfType<BallArkanoid>().ResetBall();
        FindObjectOfType<Player>().ResetPlayer();
    }
}
