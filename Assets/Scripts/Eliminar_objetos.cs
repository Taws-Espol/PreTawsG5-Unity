using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eliminar_objetos : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("choca");
        if (other.GetComponent<Barrera>() != null)
        {
            Destroy(this.gameObject);
        }
    }
}
