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
    
    void Start()
    {
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
        
    }
    private void FixedUpdate()
    {
        progresoActual += Time.fixedDeltaTime/ segundosTotales;
        barraProgreso.fillAmount = progresoActual;
    }
}
