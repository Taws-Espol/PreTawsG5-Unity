using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFlowInfinity : MonoBehaviour
{
    [Header("Progreso")]
    public GameObject rider;
    private bool gameRunning;


    private float velocidadActual;

    [Header("Audio")]
    private AudioSource sonido;

    [Header("Panel Final")]
    public GameObject  panel_Fin_del_juego;
    public TextMeshProUGUI txt_Puntaje;
    

    
    void Start()
    {
        panel_Fin_del_juego.SetActive(false);

        gameRunning = true;
        sonido = GetComponent<AudioSource>();
        velocidadActual = 1;

    }

    // Update is called once per frame
    void Update()
    {
        velocidadActual = Mathf.Max(velocidadActual, Time.timeScale);
        Debug.Log(Time.timeScale);
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameRunning = !gameRunning;
            Time.timeScale = velocidadActual * (gameRunning ? 1 : 0);
            if (gameRunning)
            {
                sonido.UnPause();
            } 
            else
            {
                sonido.Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        
        if(rider.GetComponent<PlayerController>().salud == 0){ 
            //Debug.Log("cruce_de_meta =true");

            gameRunning = false;
            Time.timeScale = velocidadActual * (gameRunning ? 1 : 0);
            if (gameRunning)
            {
                sonido.UnPause();
            } 
            else
            {
                sonido.Pause();
            }
            panel_Fin_del_juego.SetActive(true);
            

            txt_Puntaje.text = "400"+ " pts";

        }
        
        
    }


}
