using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlJuego : MonoBehaviour
{
    Nivel[] niveles = {
        new Nivel(1, 20f, 5, 5, 5, 5),
        new Nivel(2, 25f, 10, 10, 10, 10),
        new Nivel(3, 30f, 6, 6, 6, 6),
        new Nivel(4, 35f, 7, 7, 7, 7),
        new Nivel(5, 40f, 8, 8, 8, 8),
        new Nivel(6, 40f, 9, 9, 9, 9),
        new Nivel(7, 40f, 10, 10, 10, 10),
    };
    public AudioSource audioSource; // Referencia al componente AudioSource
    public AudioClip audioClip; // Referencia al clip de audio
    public GameObject jugador; // Prefab del cuadrado


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


    //PARA MOSTRAR MODALES
    public Canvas modalPerder;
    public Canvas modalGanar;

    //PARA BOTONES
    public Button botonAceptar; 
    public Button botonAceptaGanar;
    private GeneradorBloques generadorBloques; // Referencia al script GeneradorBloques


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
        kunai controlKunai = FindObjectOfType<kunai>();

        controlKunai.CambiarKunaiUno();
        // Reproduce el audio
        audioSource.PlayOneShot(audioClip);

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
        // Asigna el evento de clic al botón
        botonAceptar.onClick.AddListener(RestablecerNivelUno);
        botonAceptaGanar.onClick.AddListener(AvanzarNivel);

        generadorBloques = GetComponent<GeneradorBloques>();
        // Calcula la posición del cuadrado a la izquierda con separación y margen, ajustada a la posición inicial
        Vector3 posicionIzquierda = new Vector3(0,0.2f, 1f);

        GameObject nuevoCuadradoIzquierda = Instantiate(jugador, posicionIzquierda, Quaternion.identity);
    }

    void Update()
    {
        // Definir la posición de aparición más abajo en la pantalla
        Vector3 posicionInicial = new Vector3(0f, 0.05f, 0f); // Cambia el valor Y según lo necesites

        // Actualiza el Text con el valor del conteo de bloques
        //contadorBloquesText.text = "Bloques destruidos: " + bloquesDestruidos;
        if (tiempoActivo)
        {
            CambiarContador();
            
        }
        // Si el tiempo actual es 10 y el prefab aún no se ha instanciado
        //if (tiempoActual >= 15.0f && tiempoActual <= 15.5f && !prefabInstanciado)
        //{
        //    // Instancia el prefab
        //    instanciaPrefab = Instantiate(prefab, posicionInicial, Quaternion.identity);
        //    prefabInstanciado = true; // Actualiza la bandera
        //}
        //else if (tiempoActual <= 14.5f && instanciaPrefab != null)
        //{
        //    // Destruye la instancia del prefab después de un cierto tiempo
        //    Destroy(instanciaPrefab, 5f); // Cambia 5f al número de segundos que quieras que el prefab permanezca antes de ser destruido
        //    instanciaPrefab = null; // Actualiza la referencia a la instancia del prefab
        //}


        //PARA CONTROL DE NIVELES
        // Verificar si el nivel actual se ha completado
        if (bloquesDestruidosAzul + bloquesDestruidosMorado + bloquesDestruidosRosado + bloquesDestruidosNegro == 0)
        {
            DesactivarTemporizador();
            // Activa el canvas modalGanar si existe
            modalGanar.gameObject.SetActive(true);
           
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

            if (modalPerder != null)
            {
                // Activa el canvas modalPerder si existe
                modalPerder.gameObject.SetActive(true);
            }
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

    public void RestablecerNivelUno()
    {
        // Restablecer el nivel actual
        kunai controlKunai = FindObjectOfType<kunai>();

        controlKunai.CambiarKunaiUno();
        nivelActual = 1;
        Nivel nivel = niveles[0];
        contadorNiveles.text = "" + nivelActual;
        // Restablecer el temporizador y el número de bloques de cada color
        tiempoMaximo = nivel.segundos;
        bloquesDestruidosMorado = nivel.numMorado;
        bloquesDestruidosRosado = nivel.numRosa;
        bloquesDestruidosAzul = nivel.numAzul;
        bloquesDestruidosNegro = nivel.numNegro;

        // Restablecer los contadores de bloques destruidos
        contadorBloquesMoradoText.text = "" + bloquesDestruidosMorado;
        contadorBloquesAzulText.text = "" + bloquesDestruidosAzul;
        contadorBloquesRosaText.text = "" + bloquesDestruidosRosado;
        contadorBloquesNegroText.text = "" + bloquesDestruidosNegro;
        // Encuentra el objeto que contiene el script GeneradorBloques
        GameObject generadorObjeto = GameObject.Find("Square");

        // Obtén el componente GeneradorBloques del objeto
        if (generadorObjeto != null)
        {
            generadorBloques = generadorObjeto.GetComponent<GeneradorBloques>();
        }

        if (generadorBloques != null)
        {
            // Llama a la función generarBloques() del script GeneradorBloques
            generadorBloques.generarBloques(nivelActual);
        }
        else
        {
            Debug.LogError("No se encontró el script GeneradorBloques.");
        }
        // Restablecer el temporizador
        ActivarTemporizador();
    }

    public void AvanzarNivel()
    {
        // Avanzar al siguiente nivel
        nivelActual++;
        kunai controlKunai = FindObjectOfType<kunai>();

        controlKunai.CambiarKunaiDos();
        contadorNiveles.text = "" + nivelActual;
        tiempoActivo = false;
        if (nivelActual < niveles.Length)
        {
            // Configurar el temporizador y el número de bloques para el nuevo nivel
            Nivel nivel = niveles[nivelActual];
            tiempoMaximo = nivel.segundos;
            bloquesDestruidosMorado = nivel.numMorado;
            bloquesDestruidosRosado = nivel.numRosa;
            bloquesDestruidosAzul = nivel.numAzul;
            bloquesDestruidosNegro = nivel.numNegro;

            // Restablecer los contadores de bloques destruidos
            contadorBloquesMoradoText.text = "" + bloquesDestruidosMorado;
             contadorBloquesAzulText.text = "" + bloquesDestruidosAzul;
            contadorBloquesRosaText.text = "" + bloquesDestruidosRosado;
            contadorBloquesNegroText.text = "" + bloquesDestruidosNegro;



            // Encuentra el objeto que contiene el script GeneradorBloques
            GameObject generadorObjeto = GameObject.Find("Square");

            // Obtén el componente GeneradorBloques del objeto
            if (generadorObjeto != null)
            {
                generadorBloques = generadorObjeto.GetComponent<GeneradorBloques>();
            }

            if (generadorBloques != null)
            {
                // Llama a la función generarBloques() del script GeneradorBloques
                generadorBloques.generarBloques(nivelActual);
            }
            else
            {
                Debug.LogError("No se encontró el script GeneradorBloques.");
            }

            ActivarTemporizador();
        }
        else
        {
            // El jugador ha completado todos los niveles
            Debug.Log("¡Felicidades, has completado todos los niveles!");
        }
    }


}
