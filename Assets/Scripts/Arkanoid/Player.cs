using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidBody2d;
    private float inputValue;
    public float moveSpeed = 25;
    private Vector2 direction;
    Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        inputValue = Input.GetAxisRaw("Horizontal");
        if (inputValue == 1){
            direction = Vector2.right;
        }
        else if (inputValue == -1){
            direction = Vector2.left;
        }
        else{
            direction = Vector2.zero;
        }

        rigidBody2d.AddForce(direction * moveSpeed * Time.deltaTime *100);
    }

    public void ResetPlayer(){
        transform.position = startPosition ;
        rigidBody2d.velocity = Vector2.zero;
    }
}
