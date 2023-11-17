using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlJuego : MonoBehaviour
{
    public TextMeshProUGUI contadorBloquesAzulText; // Un objeto Text para mostrar el conteo de bloques
    public TextMeshProUGUI contadorBloquesMoradoText; // Un objeto Text para mostrar el conteo de bloques
    public TextMeshProUGUI contadorBloquesRosaText; // Un objeto Text para mostrar el conteo de bloques
    public TextMeshProUGUI contadorBloquesNegroText; // Un objeto Text para mostrar el conteo de bloques

    public int bloquesDestruidosMorado = 0; // Variable para llevar el conteo de bloques morados destruidos
    public int bloquesDestruidosAzul = 0; // Variable para llevar el conteo de bloques azules destruidos
    public int bloquesDestruidosRosado = 0; // Variable para llevar el conteo de bloques rosados destruidos
    public int bloquesDestruidosNegro = 0; // Variable para llevar el conteo de bloques negros destruidos

    // Métodos para incrementar el contador de bloques destruidos por color
    public void IncrementarBloquesDestruidosMorado()
    {
        bloquesDestruidosMorado++;
        contadorBloquesMoradoText.text = "MORADO: " + bloquesDestruidosMorado;
    }

    public void IncrementarBloquesDestruidosAzul()
    {
        bloquesDestruidosAzul++;
        contadorBloquesAzulText.text = "AZUL: " + bloquesDestruidosAzul;
    }

    public void IncrementarBloquesDestruidosRosado()
    {
        bloquesDestruidosRosado++;
        contadorBloquesRosaText.text = "ROSADO: " + bloquesDestruidosRosado;
    }

    public void IncrementarBloquesDestruidosNegro()
    {
        bloquesDestruidosNegro++;
        contadorBloquesNegroText.text = "NEGRO: " + bloquesDestruidosNegro;
    }

    void Update()
    {
        // Actualiza el Text con el valor del conteo de bloques
        //contadorBloquesText.text = "Bloques destruidos: " + bloquesDestruidos;
    }
}
