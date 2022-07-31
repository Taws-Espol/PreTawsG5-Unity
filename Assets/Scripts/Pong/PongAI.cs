using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongAI : MonoBehaviour
{
    public GameObject ball;
    public float speed = 5f;
    private Vector2 ballPos;


    void Update()
    {
        Move();
    }

    void Move()
    {
        ballPos = ball.transform.position;
        float diference = ballPos.y - transform.position.y;
        if(diference > 0){
            transform.position += (speed * Time.deltaTime > diference)? new Vector3(0, diference, 0): new Vector3(0, speed * Time.deltaTime, 0);
        }
        else{
            transform.position += (speed*Time.deltaTime > -diference)? new Vector3(0, diference, 0) : new Vector3(0, -speed * Time.deltaTime, 0);
        }
    }
}
