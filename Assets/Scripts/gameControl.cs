using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameControl : MonoBehaviour
{
    public bool gameRunning;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            changeGameRunningState();
        }
    }

    public void changeGameRunningState()
    {
        if(gameRunning){
            gameRunning=false;
        }
        else{
            gameRunning=true;
        }
        
        if(gameRunning){
            //El juego esta corriendo
            Debug.Log("El juego esta corriendo");
            Time.timeScale=1;
        }

        else{
            //El juego esta parado
            Debug.Log("El juego esta parado");
            Time.timeScale=0;
        }

    }

    public bool isGameRunning(){
        return gameRunning;
    }
}
