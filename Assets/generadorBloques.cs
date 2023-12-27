using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GeneradorBloques : MonoBehaviour
{

    public GameObject cuadradoPrefab; // Prefab del cuadrado
    public List<Sprite> spritesDisponibles; // Lista de sprites disponibles
    public List<Sprite> spriteRotos; // Lista de sprites rotos

    public int filas = 8; // N�mero de filas de cuadrados
    public int columnas = 10; // N�mero de columnas de cuadrados
    public float separacionHorizontal = 2.0f; // Separaci�n horizontal entre las matrices de bloques
    public float separacionVertical = 1.0f; // Separaci�n vertical entre bloques
    public float margenHorizontal = 0.5f; // Margen horizontal entre bloques
    public float margenVertical = 0.5f; // Margen vertical entre bloques

    void Start()
    {
        generarBloques(1);
    }

    public void generarBloques(int id)
    {
        if(id == 2)
        {
            generarTriangulo();
        }
        else
        {
            generarCuadrado();
        }

    }

    public void generarCuadrado()
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
                // Elige un sprite aleatorio
                Sprite spriteAleatorio = spritesDisponibles[Random.Range(0, spritesDisponibles.Count)];

                // Calcula la posici�n del cuadrado a la izquierda con separaci�n y margen, ajustada a la posici�n inicial
                Vector3 posicionIzquierda = new Vector3(posicionInicialIzquierda + (columna * (separacionVertical + margenHorizontal)), fila * (separacionVertical + margenVertical) - posicionVertical, 0);

                // Instancia un nuevo cuadrado a la izquierda
                GameObject nuevoCuadradoIzquierda = Instantiate(cuadradoPrefab, posicionIzquierda, Quaternion.identity);
                nuevoCuadradoIzquierda.GetComponent<SpriteRenderer>().sprite = spriteAleatorio;

                nuevoCuadradoIzquierda.transform.localScale = new Vector3(0.6f, 0.6f, 1f); // Cambia la escala 
            }
        }

        // Calcula la posici�n inicial de la matriz derecha
        float posicionInicialDerecha = (anchoPantalla / 5f);

        // Genera los cuadrados a la derecha
        for (int fila = 0; fila < filas; fila++)
        {
            for (int columna = 0; columna < columnas; columna++)
            {
                // Elige un sprite aleatorio
                Sprite spriteAleatorio = spritesDisponibles[Random.Range(0, spritesDisponibles.Count)];

                // Calcula la posici�n del cuadrado a la derecha con separaci�n horizontal y margen, ajustada a la posici�n inicial
                Vector3 posicionDerecha = new Vector3(posicionInicialDerecha + (columna * (separacionVertical + margenHorizontal)), fila * (separacionVertical + margenVertical) - posicionVertical, 0);

                // Instancia un nuevo cuadrado a la derecha
                GameObject nuevoCuadradoDerecha = Instantiate(cuadradoPrefab, posicionDerecha, Quaternion.identity);
                nuevoCuadradoDerecha.GetComponent<SpriteRenderer>().sprite = spriteAleatorio;
                nuevoCuadradoDerecha.transform.localScale = new Vector3(0.6f, 0.6f, 1f); // Cambia la escala 

            }
        }
    }

    public void generarTriangulo()
    {
        // Obtiene el ancho de la pantalla en unidades del mundo
        float anchoPantalla = Camera.main.orthographicSize * Camera.main.aspect * 2.0f;

        // Calcula la posici�n inicial de la matriz izquierda para que est� m�s a la izquierda de la pantalla
        float posicionInicialIzquierda = -(anchoPantalla / 2.4f);

        // Calcula la posici�n vertical inicial para centrar la matriz verticalmente
        float posicionVertical = (filas * (separacionVertical + margenVertical) - separacionVertical) / 2;

        // Genera los bloques en forma de tri�ngulo
        for (int fila = 0; fila < filas; fila++)
        {
            for (int columna = 0; columna < columnas - fila; columna++) // Disminuye el n�mero de columnas a medida que aumenta el n�mero de filas
            {
                // Elige un sprite aleatorio
                Sprite spriteAleatorio = spritesDisponibles[Random.Range(0, spritesDisponibles.Count)];

                // Calcula la posici�n del bloque con separaci�n y margen, ajustada a la posici�n inicial
                Vector3 posicion = new Vector3(posicionInicialIzquierda + (columna * (separacionVertical + margenHorizontal)), fila * (separacionVertical + margenVertical) - posicionVertical, 0);

                // Instancia un nuevo bloque
                GameObject nuevoBloque = Instantiate(cuadradoPrefab, posicion, Quaternion.identity);
                nuevoBloque.GetComponent<SpriteRenderer>().sprite = spriteAleatorio;

                nuevoBloque.transform.localScale = new Vector3(0.6f, 0.6f, 1f); // Cambia la escala 
            }
        }

         // Calcula la posici�n inicial de la matriz derecha
        float posicionInicialDerecha = (anchoPantalla / 5f);

        // Genera los cuadrados a la derecha
        for (int fila = 0; fila < filas; fila++)
        {
            for (int columna = 0; columna < columnas; columna++)
            {
                // Elige un sprite aleatorio
                Sprite spriteAleatorio = spritesDisponibles[Random.Range(0, spritesDisponibles.Count)];

                // Calcula la posici�n del cuadrado a la derecha con separaci�n horizontal y margen, ajustada a la posici�n inicial
                Vector3 posicionDerecha = new Vector3(posicionInicialDerecha + (columna * (separacionVertical + margenHorizontal)), fila * (separacionVertical + margenVertical) - posicionVertical, 0);

                // Instancia un nuevo cuadrado a la derecha
                GameObject nuevoCuadradoDerecha = Instantiate(cuadradoPrefab, posicionDerecha, Quaternion.identity);
                nuevoCuadradoDerecha.GetComponent<SpriteRenderer>().sprite = spriteAleatorio;
                nuevoCuadradoDerecha.transform.localScale = new Vector3(0.6f, 0.6f, 1f); // Cambia la escala 

            }
        }
    }
    public void EliminarBloques()
    {
        // Encuentra todos los objetos de tipo "bloque" en la escena
        GameObject[] bloques = GameObject.FindGameObjectsWithTag("bloque");

        // Recorre cada bloque y lo destruye
        foreach (GameObject bloque in bloques)
        {
            Destroy(bloque);
        }
    }


}
