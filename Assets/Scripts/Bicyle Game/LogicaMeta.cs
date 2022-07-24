using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaMeta : MonoBehaviour
{
    public GameObject progreso;
    public float velocidad;
    public bool cruce_de_meta = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(progreso.GetComponent<Image>().fillAmount == 1){
            transform.position += transform.right * velocidad * Time.deltaTime;
        }
        
    }
    private void OnBecameInvisible()
    {
        if (transform.position.x < -8)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            cruce_de_meta =true;
        }
    }

    
}
