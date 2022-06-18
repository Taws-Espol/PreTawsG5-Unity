using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaObjetos : MonoBehaviour
{
    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * velocidad * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        if (transform.position.x < 0)
        {
            Destroy(gameObject);
        }
    }
}
