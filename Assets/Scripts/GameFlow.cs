using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    private bool gameRunning;
    // Start is called before the first frame update
    void Start()
    {
        gameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            gameRunning = !gameRunning;
            Time.timeScale = 1 * (gameRunning ? 1 : 0);
        }
    }
}
