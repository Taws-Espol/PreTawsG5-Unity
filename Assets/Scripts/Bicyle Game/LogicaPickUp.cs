using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LogicaPickUp : MonoBehaviour
{
    private AudioSource clip;
    void Start()
    {
        clip = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            clip.Play();
            Destroy(gameObject, 1f);
        }
    }
}
