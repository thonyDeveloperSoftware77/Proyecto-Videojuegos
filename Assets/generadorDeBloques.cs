using System.Collections.Generic;
using UnityEngine;

public class generadorDeBloques : MonoBehaviour
{
    public GameObject cuadradoPrefab; // Prefab del cuadrado
    public List<Color> coloresDisponibles = new List<Color>() { Color.red, Color.blue, Color.green, Color.yellow }; // Lista de colores
    public int filas = 8; // Número de filas de cuadrados
    public int columnas = 10; // Número de columnas de cuadrados
    public float separacion = 1.0f; // Espacio entre los cuadrados

    void Start()
    {
        // Genera los cuadrados en la izquierda
        for (int fila = 0; fila < filas; fila++)
        {
            for (int columna = 0; columna < columnas; columna++)
            {
                // Elige un color aleatorio
                Color colorAleatorio = Color.red;

                // Calcula la posición del cuadrado en la izquierda
                Vector3 posicionIzquierda = new Vector3(columna * separacion, fila * separacion, 0);

                // Instancia un nuevo cuadrado en la izquierda
                GameObject nuevoCuadradoIzquierda = Instantiate(cuadradoPrefab, posicionIzquierda, Quaternion.identity);
                nuevoCuadradoIzquierda.GetComponent<SpriteRenderer>().color = colorAleatorio;
            }
        }

        // Genera los cuadrados en la derecha
        for (int fila = 0; fila < filas; fila++)
        {
            for (int columna = 0; columna < columnas; columna++)
            {
                // Elige un color aleatorio
                Color colorAleatorio = Color.red;


                // Calcula la posición del cuadrado en la derecha
                Vector3 posicionDerecha = new Vector3(columna * separacion + columnas * separacion, fila * separacion, 0);

                // Instancia un nuevo cuadrado en la derecha
                GameObject nuevoCuadradoDerecha = Instantiate(cuadradoPrefab, posicionDerecha, Quaternion.identity);
                nuevoCuadradoDerecha.GetComponent<SpriteRenderer>().color = colorAleatorio;
            }
        }
    }
}