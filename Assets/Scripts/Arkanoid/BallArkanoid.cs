using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallArkanoid : MonoBehaviour
{
    public Rigidbody2D rigidBody2d;
    public float speed = 300;
    private Vector2 velocity;
    Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        ResetBall();
    }

    private void OnCollisionEnter2D (Collision2D collision){
        if (collision.gameObject.CompareTag("DeadZone")){
            FindObjectOfType<GameManagerArkanoid>().LoseHealth();
        }
    }

    public void ResetBall(){
        transform.position = startPosition;
        rigidBody2d.velocity = Vector2.zero;

        velocity.x = Random.Range(-1f,-1f);

        velocity.y = 1;

        rigidBody2d.AddForce(velocity*speed);
        
    }
}
