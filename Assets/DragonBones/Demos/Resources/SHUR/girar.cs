using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girar : MonoBehaviour
{
    public float moveSpeed = 10f; // Velocidad de movimiento
    public float rotateSpeed = 1000f; // Velocidad de rotaci�n
    private Vector2 startPosition; // Posici�n inicial
    public float maxDistance = 10f; // Distancia m�xima a la que se mover� el shuriken

    void Start()
    {
        // Guarda la posici�n inicial
        startPosition = transform.position;
    }

    void Update()
    {
        // Calcula la nueva posici�n
        float newX = startPosition.x + Mathf.PingPong(Time.time * moveSpeed, maxDistance * 2) - maxDistance;

        // Mueve el shuriken a la nueva posici�n
        transform.position = new Vector2(newX, transform.position.y);

        // Rota el shuriken sobre su eje Z
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
    }
}
