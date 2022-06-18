using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaFondo : MonoBehaviour
{
    public float velocidad;
    public float numeroSprites;
    public int ordenSprite;
    private float spriteWight, startPosition;
    private Transform cameraTransform;
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        spriteWight = GetComponent<SpriteRenderer>().bounds.size.x;
        transform.position = transform.position + new Vector3(spriteWight * ordenSprite, 0, 0);
        startPosition = transform.position.x;
    }
    void Update()
    {
        transform.position -= transform.right * velocidad * Time.deltaTime;
        float posicion = transform.position.x;
        if (cameraTransform.position.x > posicion + spriteWight)
        {
            transform.Translate(new Vector3(spriteWight * numeroSprites, 0, 0));
            startPosition += spriteWight * numeroSprites;
        }
    }
}
