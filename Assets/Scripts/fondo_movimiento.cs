using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fondo_movimiento : MonoBehaviour
{
    public float velocidad = 2f;
    public float numero_de_sprites;
    public int ubicar_orden_sprite;
    private float spriteWight, startPosition;
    private Transform cameraTransform;
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        spriteWight = GetComponent<SpriteRenderer>().bounds.size.x;
        transform.position = transform.position + new Vector3(spriteWight * ubicar_orden_sprite, 0, 0);
        startPosition = transform.position.x;
    }
    void Update()
    {
        transform.position -= transform.right * velocidad * Time.deltaTime;
        float posicion = transform.position.x;
        if (cameraTransform.position.x > posicion + spriteWight)
        {
            transform.Translate(new Vector3(spriteWight * numero_de_sprites, 0, 0));
            startPosition += spriteWight * numero_de_sprites;
        }
    }

    private void LateUpdate()
    {
        //float moveAmount = Camera.tra
    }
}
