using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GeneradorBloques : MonoBehaviour
{

    public GameObject cuadradoPrefab; // Prefab del cuadrado
    public List<Sprite> spritesDisponibles; // Lista de sprites disponibles
    public List<Sprite> spriteRotos; // Lista de sprites rotos

    public int filas = 8; // Número de filas de cuadrados
    public int columnas = 10; // Número de columnas de cuadrados
    public float separacionHorizontal = 2.0f; // Separación horizontal entre las matrices de bloques
    public float separacionVertical = 1.0f; // Separación vertical entre bloques
    public float margenHorizontal = 0.5f; // Margen horizontal entre bloques
    public float margenVertical = 0.5f; // Margen vertical entre bloques

    void Start()
    {
        // Obtiene el ancho de la pantalla en unidades del mundo
        float anchoPantalla = Camera.main.orthographicSize * Camera.main.aspect * 2.0f;

        // Calcula la posición inicial de la matriz izquierda para que esté más a la izquierda de la pantalla
        float posicionInicialIzquierda = -(anchoPantalla / 2.4f);

        // Calcula la posición vertical inicial para centrar la matriz verticalmente
        float posicionVertical = (filas * (separacionVertical + margenVertical) - separacionVertical) / 2;

        // Genera los cuadrados a la izquierda
        for (int fila = 0; fila < filas; fila++)
        {
            for (int columna = 0; columna < columnas; columna++)
            {
                // Elige un sprite aleatorio
                Sprite spriteAleatorio = spritesDisponibles[Random.Range(0, spritesDisponibles.Count)];

                // Calcula la posición del cuadrado a la izquierda con separación y margen, ajustada a la posición inicial
                Vector3 posicionIzquierda = new Vector3(posicionInicialIzquierda + (columna * (separacionVertical + margenHorizontal)), fila * (separacionVertical + margenVertical) - posicionVertical, 0);

                // Instancia un nuevo cuadrado a la izquierda
                GameObject nuevoCuadradoIzquierda = Instantiate(cuadradoPrefab, posicionIzquierda, Quaternion.identity);
                nuevoCuadradoIzquierda.GetComponent<SpriteRenderer>().sprite = spriteAleatorio;

                nuevoCuadradoIzquierda.transform.localScale = new Vector3(0.6f, 0.6f, 1f); // Cambia la escala 
            }
        }

        // Calcula la posición inicial de la matriz derecha
        float posicionInicialDerecha = (anchoPantalla / 5f);

        // Genera los cuadrados a la derecha
        for (int fila = 0; fila < filas; fila++)
        {
            for (int columna = 0; columna < columnas; columna++)
            {
                // Elige un sprite aleatorio
                Sprite spriteAleatorio = spritesDisponibles[Random.Range(0, spritesDisponibles.Count)];

                // Calcula la posición del cuadrado a la derecha con separación horizontal y margen, ajustada a la posición inicial
                Vector3 posicionDerecha = new Vector3(posicionInicialDerecha + (columna * (separacionVertical + margenHorizontal)), fila * (separacionVertical + margenVertical) - posicionVertical, 0);

                // Instancia un nuevo cuadrado a la derecha
                GameObject nuevoCuadradoDerecha = Instantiate(cuadradoPrefab, posicionDerecha, Quaternion.identity);
                nuevoCuadradoDerecha.GetComponent<SpriteRenderer>().sprite = spriteAleatorio;
                nuevoCuadradoDerecha.transform.localScale = new Vector3(0.6f, 0.6f, 1f); // Cambia la escala 

            }
        }
    }
}
