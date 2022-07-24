using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObstacles : MonoBehaviour
{

    public GameObject[] obstaculos; //[carro1 (lento), carro2 (medio), carro3(cambia de posicion),  bache]
    public float tiempoCreacion = 2f;
    private float[] posiciones;
    private float posX = 12f;

    void Start(){
        posiciones = new float[3];
        posiciones[0] = 2.7f;
        posiciones[1] = 0f;
        posiciones[2] = -2.6f;
        Invoke("Creando", 0.0f);
        Invoke("Cancelar", 15f);
        Invoke("Patron2", 16f);
    }

    private void Cancelar(){
        CancelInvoke("CrearAleatorio");
    }

    private void Creando(){
        InvokeRepeating("CrearAleatorio", tiempoCreacion, tiempoCreacion);
    }

    private void CrearAleatorio(){
        int idx = Random.Range(0, 3);
        int idxObjeto = Random.Range(0, 1);
        Vector3 spawnPosition = new Vector3(posX, posiciones[idx], 0);
        GameObject obstaculo = Instantiate(obstaculos[idxObjeto], spawnPosition, Quaternion.identity);
    }

        private void CrearBache(){
        int idx = Random.Range(0, 3);
        Vector3 spawnPosition = new Vector3(posX, posiciones[idx], 0);
        GameObject obstaculo = Instantiate(obstaculos[3], spawnPosition, Quaternion.identity);
    }
        private void CrearAutoCambiente(){
       int idx = Random.Range(0, 3);
        Vector3 spawnPosition = new Vector3(posX, posiciones[idx], 0);
        GameObject obstaculo = Instantiate(obstaculos[2], spawnPosition, Quaternion.identity);
    
    }

    private void Patron1(){
        Invoke("MuroArriba", 0f);
        Invoke("MuroAbajo", 2.5f);
        Invoke("MuroArriba", 5f);
        Invoke("MuroAbajo", 7.5f);
        Invoke("MuroArriba", 10f);
        Invoke("MuroAbajo", 12.5f);
        Invoke("MuroExtremo", 15f);
        InvokeRepeating("CrearAleatorio", 20f, tiempoCreacion);
        Invoke("Cancelar", 22f);
        Invoke("Patron2", 23f);
        //Patron 2
    }

    private void Patron2 (){
        Invoke("CrearBache", 0f);
        Invoke("MuroExtremo", 1f);
        Invoke("CrearAleatorio",2.5f);
        Invoke("MuroAbajo", 5f);
        Invoke("MuroExtremo", 7.5f);
        Invoke("CrearAutoCambiente",9f);
        Invoke("CrearBache", 12f);
        Invoke("MuroArriba", 14f);
        InvokeRepeating("CrearAleatorio", 16f, tiempoCreacion);
        Invoke("Cancelar", 18f);
        Invoke("Patron3", 19f);
        //Funci�n
        //Cancelar
        //Patron 3
    }

    private void Patron3 (){
        Invoke("CrearBache", 0f);
        Invoke("CrearAutoCambiente",1f);
        Invoke("MuroAbajo", 2.5f);
        Invoke("MuroArriba", 4.5f);
        Invoke("CrearAutoCambiente",9f);
        Invoke("CrearBache", 12f);
        Invoke("MuroArriba", 15f);
        Invoke("CrearBache", 16f);
         Invoke("MuroExtremo", 19f);

        Invoke("Cancelar", 20f);
        Invoke("Patron1", 21f);
        
        //Funci�n
        //Cancelar
        //Dejar espacio hasta el final
    }

    private void MuroArriba (){
        int idxTmp = Random.Range(0, 2);
        GameObject obstaculo1 = Instantiate(obstaculos[idxTmp], new Vector3(posX, posiciones[0], 0), Quaternion.identity);
        GameObject obstaculo2 = Instantiate(obstaculos[idxTmp], new Vector3(posX, posiciones[1], 0), Quaternion.identity);
    }

    private void MuroAbajo(){
        int idxTmp = Random.Range(0, 2);
        GameObject obstaculo1 = Instantiate(obstaculos[idxTmp], new Vector3(posX, posiciones[1], 0), Quaternion.identity);
        GameObject obstaculo2 = Instantiate(obstaculos[idxTmp], new Vector3(posX, posiciones[2], 0), Quaternion.identity);
    }

    private void MuroExtremo(){
        int idxTmp = Random.Range(0, 2);
        GameObject obstaculo1 = Instantiate(obstaculos[idxTmp], new Vector3(posX, posiciones[0], 0), Quaternion.identity);
        GameObject obstaculo2 = Instantiate(obstaculos[idxTmp], new Vector3(posX, posiciones[2], 0), Quaternion.identity);
    }
}
