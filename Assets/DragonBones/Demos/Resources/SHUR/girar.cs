using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girar : MonoBehaviour
{
    public float moveSpeed = 10f; // Velocidad de movimiento
    public float rotateSpeed = 1000f; // Velocidad de rotación
    private Vector2 startPosition; // Posición inicial
    public float maxDistance = 10f; // Distancia máxima a la que se moverá el shuriken


    void Update()
    {
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
    }
}
