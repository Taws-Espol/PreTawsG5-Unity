using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    [Header("Barra Progreso")]
    private bool gameRunning;
    public Image barraProgreso;
    private float progresoActual = 0;
    private float segundosTotales = 62;

    private float velocidadActual;

    [Header("Audio")]
    private AudioSource sonido;

    [Header("Panel Final")]
    public GameObject  Panel_Fin_del_juego;
    public GameObject Txt_Puntaje;
    public GameObject Meta;
    

    
    void Start()
    {
        Panel_Fin_del_juego.SetActive(false);

        barraProgreso.fillAmount = 0;
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

        if(Meta.GetComponent<LogicaMeta>().cruce_de_meta){ 
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
            Panel_Fin_del_juego.SetActive(true);
            

            //Txt_Puntaje.GetComponent<Text>() = "400"+ " pts";

        }
        
    }
    private void FixedUpdate()
    {
        progresoActual += Time.fixedDeltaTime/ segundosTotales;
        barraProgreso.fillAmount = progresoActual;
    }


}
