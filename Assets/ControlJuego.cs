using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlJuego : MonoBehaviour
{

    ///TEMPORIZADOR
    [SerializeField] private float tiempoMaximo;
    private float tiempoActual;
    private bool tiempoActivo = true;
    [SerializeField] private Slider slider;
    
    
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
        contadorBloquesMoradoText.text = "" + bloquesDestruidosMorado;
    }

    public void IncrementarBloquesDestruidosAzul()
    {
        bloquesDestruidosAzul++;
        contadorBloquesAzulText.text = "" + bloquesDestruidosAzul;
    }

    public void IncrementarBloquesDestruidosRosado()
    {
        bloquesDestruidosRosado++;
        contadorBloquesRosaText.text = "" + bloquesDestruidosRosado;
    }

    public void IncrementarBloquesDestruidosNegro()
    {
        bloquesDestruidosNegro++;
        contadorBloquesNegroText.text = "" + bloquesDestruidosNegro;
    }

    private void Start()
    {
        ActivarTemporizador();
    }

    void Update()
    {
        // Actualiza el Text con el valor del conteo de bloques
        //contadorBloquesText.text = "Bloques destruidos: " + bloquesDestruidos;
        if(tiempoActivo)
        {
            CambiarContador();
        }
    }

    private void CambiarContador()
    {
        tiempoActual -= Time.deltaTime;

        if(tiempoActual >= 0)
        {
            slider.value = tiempoActual;
        }
        if(tiempoActual <= 0)
        {
            Debug.Log("Derrota");
            tiempoActivo = false;
        }
    }

    private void CambiarTemporizador(bool estado)
    {
        tiempoActivo = estado;
    }

    public void ActivarTemporizador()
    {
        tiempoActual = tiempoMaximo;
        slider.maxValue = tiempoMaximo;
        CambiarTemporizador(true);
    }

    public void DesactivarTemporizador()
    {
        CambiarTemporizador(false);
    }
}
