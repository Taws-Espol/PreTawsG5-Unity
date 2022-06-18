using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObstacles : MonoBehaviour
{

    public GameObject[] obstaculos;
    public float tiempoCreacion = 2f;
    private float[] posiciones;
    // Start is called before the first frame update
    void Start()
    {
        posiciones = new float[3];
        posiciones[0] = 2.7f;
        posiciones[1] = 0f;
        posiciones[2] = -2.6f;
        Invoke("Creando", 0.0f);
        Invoke("Cancelar", 15f);
        Invoke("Patron1", 16f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Cancelar()
    {
        CancelInvoke("CrearAleatorio");
    }

    private void Creando()
    {
        InvokeRepeating("CrearAleatorio", 0.0f, tiempoCreacion);
    }

    private void CrearAleatorio()
    {
        int idx = Random.Range(0, 3);
        int idxObjeto = Random.Range(0, 2);
        Vector3 spawnPosition = new Vector3(20, posiciones[idx], 0);
        GameObject obstaculo = Instantiate(obstaculos[idxObjeto], spawnPosition, Quaternion.identity);
    }

    private void Patron1()
    {
        Invoke("MuroArriba", 0f);
        Invoke("MuroAbajo", 2.5f);
        Invoke("MuroArriba", 5f);
        Invoke("MuroAbajo", 7.5f);
        Invoke("MuroArriba", 10f);
        Invoke("MuroAbajo", 12.5f);
        Invoke("MuroExtremo", 15f);
        InvokeRepeating("CrearAleatorio", 20f, tiempoCreacion);
        //Cancelar
        //Patron 2
    }

    private void Patron2 ()
    {
        //Función
        //Cancelar
        //Patron 3
    }

    private void Patron3 ()
    {
        //Función
        //Cancelar
        //Dejar espacio hasta el final
    }

    private void MuroArriba ()
    {
        int idxTmp = Random.Range(0, 2);
        GameObject obstaculo1 = Instantiate(obstaculos[idxTmp], new Vector3(20, posiciones[0], 0), Quaternion.identity);
        GameObject obstaculo2 = Instantiate(obstaculos[idxTmp], new Vector3(20, posiciones[1], 0), Quaternion.identity);
    }

    private void MuroAbajo()
    {
        int idxTmp = Random.Range(0, 2);
        GameObject obstaculo1 = Instantiate(obstaculos[idxTmp], new Vector3(20, posiciones[1], 0), Quaternion.identity);
        GameObject obstaculo2 = Instantiate(obstaculos[idxTmp], new Vector3(20, posiciones[2], 0), Quaternion.identity);
    }

    private void MuroExtremo()
    {
        int idxTmp = Random.Range(0, 2);
        GameObject obstaculo1 = Instantiate(obstaculos[idxTmp], new Vector3(20, posiciones[0], 0), Quaternion.identity);
        GameObject obstaculo2 = Instantiate(obstaculos[idxTmp], new Vector3(20, posiciones[2], 0), Quaternion.identity);
    }
}
