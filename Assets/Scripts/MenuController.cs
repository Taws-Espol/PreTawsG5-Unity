using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    //Scrpit a button to call this function
    public void LoadScene(int index)
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }

    public void Exit(){
        Application.Quit();
    }


}
