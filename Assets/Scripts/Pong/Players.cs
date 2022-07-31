using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public bool playerLeft;
    public float speed = 15f;
    public Rigidbody2D rb;

    public Vector2 startPos;
    public Vector3 move;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        move = playerLeft? new Vector3(0,Input.GetAxis("Vertical1"),0) : new Vector3(0,Input.GetAxis("Vertical2"),0);
        transform.position += move * speed * Time.deltaTime;
        float posY = Mathf.Clamp(transform.position.y, -3.25f, 3.25f);
        transform.position = playerLeft? new Vector3(-8,posY,0): new Vector3(8,posY,0);
    }
    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPos;
    }
}

