using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public bool player1;
    public float speed = 200f;
    public Rigidbody2D rb;

    private float move;
    public Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (player1)
        {
            move = Input.GetAxis("Vertical1");
        }
        else
        {
            move = Input.GetAxis("Vertical2");
        }
        rb.velocity = new Vector2(0, move * speed * Time.deltaTime);
    }
    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPos;
    }
}

