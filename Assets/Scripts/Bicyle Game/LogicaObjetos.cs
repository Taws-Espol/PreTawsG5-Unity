using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaObjetos : MonoBehaviour
{
    public float velocidad;
    float[] posiciones = new float[3];
    public float posX = 12;
    void Start()
    {
        if (gameObject.tag != "Obstacle")
            {
                posiciones[0] = 2.3f;
                posiciones[1] = -0.5f;
                posiciones[2] = -3.3f;
                definePosition();
            }
        
    }

    void Update()
    {
        transform.position += transform.right * velocidad * Time.deltaTime;
        if (transform.position.x < -15){
            //If it is a Obstacle then destroy it
            if (gameObject.tag == "Obstacle")
            {
                Destroy(gameObject);
            }
            OnBecameInvisible();
        }
    }

    private void OnBecameInvisible()
    {
        definePosition();
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.collider.CompareTag("Player")){
            //If the object is not a obstacle, try OnBecameInvisible()
            if (!gameObject.CompareTag("Obstacle")){
                OnBecameInvisible();
            }
            
        }
    }
    public void definePosition(){
        int idx = Random.Range(0, 2);
        Vector3 spawnPosition = new Vector3(posX, posiciones[idx], 0);
        transform.position = spawnPosition;
    }
}
