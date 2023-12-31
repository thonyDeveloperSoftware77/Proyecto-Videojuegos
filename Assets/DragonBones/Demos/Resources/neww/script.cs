using DragonBones;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{


    // Start is called before the first frame update
    public float speed = 10.0f; // Velocidad de movimiento
    public float jumpForce = 5.0f; // Fuerza del salto
    private int isJumping = 0; // Para controlar el salto
    private UnityArmatureComponent armatureComponent; // Para controlar las animaciones
    float animationDelay = 0.05f;  // Retraso de 50 milisegundos
    float timeSinceAnimationStart = 0f;

    void Start()
    {
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        // Obtiene el componente UnityArmatureComponent
        armatureComponent = GetComponent<UnityArmatureComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isJumping);
        // Salto
        if (Input.GetButtonDown("Jump") && isJumping < 3) // Cambi� <3 a <2 para permitir dos saltos
        {
            // Reproduce la animaci�n y ajusta la velocidad
            armatureComponent.animation.Play("frenei", 1);
            armatureComponent.animation.timeScale = 0.5f;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping++;
        }
        // Si el personaje no est� en movimiento, ejecuta la animaci�n "quieto"
        /*if (!isMoving)
        {
            armatureComponent.animation.Play("quieto", 0);
        }*/
    }

    // Detecta cuando el objeto toca el suelo
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isJumping = 0;
        }
    }
}
