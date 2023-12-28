using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girar : MonoBehaviour
{
    public float moveSpeed = 10f; // Velocidad de movimiento
    public float rotateSpeed = 1000f; // Velocidad de rotaci�n
    private Vector2 startPosition; // Posici�n inicial
    public float maxDistance = 10f; // Distancia m�xima a la que se mover� el shuriken


    void Update()
    {
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
    }
}
