using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject;
    public int pooledAmount;
    List<GameObject> pooledObjects;

    public float tiempoCreacion = 2f;
    private float[] posiciones;
    private float posX = 12;

    void Start(){
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++){
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }    

        posiciones = new float[3];
        posiciones[0] = 2.3f;
        posiciones[1] = -0.5f;
        posiciones[2] = -3.3f;
        InvokeRepeating("CrearPickUp", tiempoCreacion, tiempoCreacion);
    }

    public void CrearPickUp(){
        int idx = Random.Range(0, 2);
        Vector3 spawnPosition = new Vector3(posX, posiciones[idx], 0);
        GameObject newObject = GetPooledObject();
        newObject.SetActive(true);
        newObject.transform.position = spawnPosition;
        
    }

    public GameObject GetPooledObject(){
        for(int i =0; i<pooledObjects.Count; i++){
            if(!pooledObjects[i].activeInHierarchy){
                return pooledObjects[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj; 
    }
}
