using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlJuego : MonoBehaviour
{
    Nivel[] niveles = {
        new Nivel(1, 30f, 5, 5, 5, 5),
        new Nivel(2, 35f, 10, 10, 10, 10),
        new Nivel(3, 40f, 15, 15, 15, 15)
    };

    ///TEMPORIZADOR
    [SerializeField] private float tiempoMaximo;
    private float tiempoActual;
    private bool tiempoActivo = true;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject prefab; // Referencia al prefab
    private bool prefabInstanciado = false; // Bandera para controlar si el prefab ya se instanció
    private GameObject instanciaPrefab; // Referencia a la instancia del prefab

    // Array de niveles
    private int nivelActual = 1;



    public TextMeshProUGUI contadorBloquesAzulText; // Un objeto Text para mostrar el conteo de bloques
    public TextMeshProUGUI contadorBloquesMoradoText; // Un objeto Text para mostrar el conteo de bloques
    public TextMeshProUGUI contadorBloquesRosaText; // Un objeto Text para mostrar el conteo de bloques
    public TextMeshProUGUI contadorBloquesNegroText; // Un objeto Text para mostrar el conteo de bloques
    public TextMeshProUGUI contadorNiveles; // Un objeto Text para mostrar el conteo de niveles

    public int bloquesDestruidosMorado = 5; // Variable para llevar el conteo de bloques morados destruidos
    public int bloquesDestruidosAzul = 5; // Variable para llevar el conteo de bloques azules destruidos
    public int bloquesDestruidosRosado = 5; // Variable para llevar el conteo de bloques rosados destruidos
    public int bloquesDestruidosNegro = 5; // Variable para llevar el conteo de bloques negros destruidos

    // Métodos para incrementar el contador de bloques destruidos por color
    public void IncrementarBloquesDestruidosMorado()
    {
        if(bloquesDestruidosMorado != 0)
        {
            bloquesDestruidosMorado--;
            contadorBloquesMoradoText.text = "" + bloquesDestruidosMorado;
        }
    }

    public void IncrementarBloquesDestruidosAzul()
    {
        if(bloquesDestruidosAzul != 0)
        {
            bloquesDestruidosAzul--;
            contadorBloquesAzulText.text = "" + bloquesDestruidosAzul;
        }
    }

    public void IncrementarBloquesDestruidosRosado()
    {
        if(bloquesDestruidosRosado!= 0)
        {
            bloquesDestruidosRosado--;
            contadorBloquesRosaText.text = "" + bloquesDestruidosRosado;
        }
    }

    public void IncrementarBloquesDestruidosNegro()
    {
        if (bloquesDestruidosNegro != 0)
        {
            bloquesDestruidosNegro--;
            contadorBloquesNegroText.text = "" + bloquesDestruidosNegro;
        }
    }

    private void Start()
    {
        // Inicializar el nivel actual
        Nivel nivelActual = niveles[0];

        // Configurar el temporizador y el número de shurikens
        tiempoMaximo = nivelActual.segundos;
        // Configurar el temporizador y el número de bloques de cada color
        tiempoMaximo = nivelActual.segundos;
        bloquesDestruidosMorado = nivelActual.numMorado;
        bloquesDestruidosRosado = nivelActual.numRosa;
        bloquesDestruidosAzul = nivelActual.numAzul;
        bloquesDestruidosNegro = nivelActual.numNegro;

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
        // Si el tiempo actual es 10 y el prefab aún no se ha instanciado
        if (tiempoActual >= 15.0f && tiempoActual <= 15.5f && !prefabInstanciado)
        {
            // Instancia el prefab
            instanciaPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            prefabInstanciado = true; // Actualiza la bandera
        }
        else if (tiempoActual <= 14.5f && instanciaPrefab != null)
        {
            // Destruye la instancia del prefab después de un cierto tiempo
            Destroy(instanciaPrefab, 5f); // Cambia 5f al número de segundos que quieras que el prefab permanezca antes de ser destruido
            instanciaPrefab = null; // Actualiza la referencia a la instancia del prefab
        }


        //PARA CONTROL DE NIVELES
        // Verificar si el nivel actual se ha completado
        if (bloquesDestruidosAzul + bloquesDestruidosMorado + bloquesDestruidosRosado + bloquesDestruidosNegro == 0)
        {
            // Avanzar al siguiente nivel
            nivelActual++;
            contadorNiveles.text = "" + nivelActual;
            tiempoActivo = false;
            if (nivelActual < niveles.Length)
            {
                // Configurar el temporizador y el número de shurikens para el nuevo nivel
                tiempoMaximo = niveles[nivelActual].segundos;
                tiempoActivo = true;
            }
            else
            {
                // El jugador ha completado todos los niveles
                Debug.Log("¡Felicidades, has completado todos los niveles!");
            }
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
