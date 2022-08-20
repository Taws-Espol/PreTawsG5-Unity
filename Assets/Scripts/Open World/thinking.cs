using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thinking : MonoBehaviour
{
    public GameObject thinking_obj;
    private bool is_visible = false;
    void Start(){
        thinking_obj.SetActive(false);
    }

    void Update(){
        //Si pasa el evento de que el jugador esta pensando
        //if(GameObject.Find("Player").GetComponent<player_controller>().is_thinking)
        if(Input.GetKeyDown(KeyCode.Space)){
            StartThinking();
        }
    }
    public void StartThinking(){
        thinking_obj.SetActive(is_visible);
        is_visible = !is_visible;
        //iniciar animacion de pensar
    }
}
