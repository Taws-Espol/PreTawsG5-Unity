using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover_jugador : MonoBehaviour
{
    static float speed =10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) transform.Translate(new Vector3(0, 1,0) * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.DownArrow)) transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);

    }
}
