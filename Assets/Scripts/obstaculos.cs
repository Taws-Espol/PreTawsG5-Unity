using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaculos : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemigo;
    public float tiempoCreacion;
    public GameObject posicion1; //ubicar posision con empty gameobject
    public GameObject posicion2;
    public GameObject posicion3;
    
    
    void Start()
    {
        InvokeRepeating("Creando", 0.0f, tiempoCreacion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Creando()
    {
        Vector2 posicion = new Vector2(0, 0);
        GameObject[] posiciones = { posicion1, posicion2, posicion3 };

        posicion = this.transform.position + posiciones[Random.Range(0,3)].transform.position;
        posicion = new Vector2(this.transform.position.x, posicion.y);

        GameObject enemigos = Instantiate(enemigo, posicion, Quaternion.identity);
        
    }
}
