using System.Collections.Generic;
using UnityEngine;

public class GeneradorBloques : MonoBehaviour
{
    public GameObject cuadradoPrefab; // Prefab del cuadrado
    public List<Color> coloresDisponibles = new List<Color>() { Color.red, Color.blue, Color.green, Color.yellow }; // Lista de colores
    public int filas = 8; // N�mero de filas de cuadrados
    public int columnas = 10; // N�mero de columnas de cuadrados
    public float separacionHorizontal = 2.0f; // Separaci�n horizontal entre las matrices de bloques
    public float separacionVertical = 1.0f; // Separaci�n vertical entre bloques
    public float margenHorizontal = 0.5f; // Margen horizontal entre bloques
    public float margenVertical = 0.5f; // Margen vertical entre bloques

    void Start()
    {
        // Obtiene el ancho de la pantalla en unidades del mundo
        float anchoPantalla = Camera.main.orthographicSize * Camera.main.aspect * 2.0f;

        // Calcula la posici�n inicial de la matriz izquierda para que est� m�s a la izquierda de la pantalla
        float posicionInicialIzquierda = -(anchoPantalla / 2.4f);

        // Calcula la posici�n vertical inicial para centrar la matriz verticalmente
        float posicionVertical = (filas * (separacionVertical + margenVertical) - separacionVertical) / 2;

        // Genera los cuadrados a la izquierda
        for (int fila = 0; fila < filas; fila++)
        {
            for (int columna = 0; columna < columnas; columna++)
            {
                // Elige un color aleatorio
                Color colorAleatorio = coloresDisponibles[Random.Range(0, coloresDisponibles.Count)];

                // Calcula la posici�n del cuadrado a la izquierda con separaci�n y margen, ajustada a la posici�n inicial
                Vector3 posicionIzquierda = new Vector3(posicionInicialIzquierda + (columna * (separacionVertical + margenHorizontal)), fila * (separacionVertical + margenVertical) - posicionVertical, 0);

                // Instancia un nuevo cuadrado a la izquierda
                GameObject nuevoCuadradoIzquierda = Instantiate(cuadradoPrefab, posicionIzquierda, Quaternion.identity);
                nuevoCuadradoIzquierda.GetComponent<SpriteRenderer>().color = colorAleatorio;
            }
        }

        // Calcula la posici�n inicial de la matriz derecha
        float posicionInicialDerecha = (anchoPantalla / 5f);

        // Genera los cuadrados a la derecha
        for (int fila = 0; fila < filas; fila++)
        {
            for (int columna = 0; columna < columnas; columna++)
            {
                // Elige un color aleatorio
                Color colorAleatorio = coloresDisponibles[Random.Range(0, coloresDisponibles.Count)];

                // Calcula la posici�n del cuadrado a la derecha con separaci�n horizontal y margen, ajustada a la posici�n inicial
                Vector3 posicionDerecha = new Vector3(posicionInicialDerecha + (columna * (separacionVertical + margenHorizontal)), fila * (separacionVertical + margenVertical) - posicionVertical, 0);

                // Instancia un nuevo cuadrado a la derecha
                GameObject nuevoCuadradoDerecha = Instantiate(cuadradoPrefab, posicionDerecha, Quaternion.identity);
                nuevoCuadradoDerecha.GetComponent<SpriteRenderer>().color = colorAleatorio;
            }
        }
    }
}
