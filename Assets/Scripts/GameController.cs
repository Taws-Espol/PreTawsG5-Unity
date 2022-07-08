using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Slider controlVolumen;       //La barra que representa la cantidad de volumen en el juego.
    [SerializeField] private GameObject menu;
    
    public GameObject[] audios;
    private bool isPaused = false;
    void Start(){
        menu.SetActive(false);
        Time.timeScale = 1;
        audios = GameObject.FindGameObjectsWithTag("Audio");
        controlVolumen.value = PlayerPrefs.GetFloat("Volumen");
    }

    void Update(){   
        if (Input.GetKeyDown(KeyCode.Escape)){//If press escape, open menu
            ChangePauseState();
        }

        foreach(GameObject audio in audios){
            audio.GetComponent<AudioSource>().volume = controlVolumen.value;
        }
        
    }

    private void ChangePauseState(){
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        menu.SetActive(isPaused);
    }

    public void GuardarVolumen(){
        PlayerPrefs.SetFloat("Volume", controlVolumen.value);
    }
}
