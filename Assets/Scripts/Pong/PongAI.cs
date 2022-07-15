using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongAI : MonoBehaviour
{
    public GameObject ball;
    public float speed = 200f;
    private Vector2 ballPos;

    void Update(){
        Move();
    }

    void Move(){
        ballPos= ball.transform.position;

        transform.position += transform.position.y < ballPos.y? new Vector3(0, speed * Time.deltaTime, 0) : new Vector3(0, -speed * Time.deltaTime, 0);
    }
}
