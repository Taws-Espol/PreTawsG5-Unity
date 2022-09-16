using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int index;
    public int posx;
    public int posy;

     public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.SavePosicion(posx, posy);
            UnityEngine.SceneManagement.SceneManager.LoadScene(index);
        }
    }
}
