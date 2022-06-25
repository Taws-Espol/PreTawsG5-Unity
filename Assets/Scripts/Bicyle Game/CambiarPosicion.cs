using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarPosicion : MonoBehaviour
{
    private float[] posiciones;
    // Start is called before the first frame update
    void Start()
    {
        posiciones = new float[3];
        posiciones[0] = 2.7f;
        posiciones[1] = 0f;
        posiciones[2] = -2.6f;
        StartCoroutine(ChangePosition(0.5f,3));
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator ChangePosition(float lerpduration, int sec_espera)
    {
        yield return new WaitForSeconds(sec_espera);
        int newidx = 0;
        do{
            newidx = Random.Range(0, 3);
        }while(posiciones[newidx] == transform.position.y);

        Vector3 nextPosition = new Vector3(transform.position.x,posiciones[newidx],0);
        float timeElepsed = 0f;
        
        
        while(timeElepsed< lerpduration)
        {
            transform.position = Vector3.Lerp(transform.position,nextPosition,timeElepsed/lerpduration);
            timeElepsed += Time.deltaTime;
            yield return null;
        }
    }

}
