using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCoins : MonoBehaviour
{

    public GameObject monedas;
    public float tiempoCreacion = 2f;
    private float[] posiciones;
    // Start is called before the first frame update
    void Start()
    {
        posiciones = new float[3];
        posiciones[0] = 2.3f;
        posiciones[1] = -0.5f;
        posiciones[2] = -3.3f;
        InvokeRepeating("Creando", 0.0f, tiempoCreacion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Creando()
    {
        int idx = Random.Range(0, 2);
        Vector3 spawnPosition = new Vector3(20, posiciones[idx], 0);
        GameObject moneda = Instantiate(monedas, spawnPosition, Quaternion.identity);
    }
}
