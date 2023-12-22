using DragonBones;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{


    // Start is called before the first frame update
    public float speed = 10.0f; // Velocidad de movimiento
    public float jumpForce = 5.0f; // Fuerza del salto
    private bool isJumping = false; // Para controlar el salto
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

        // Salto
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            // Reproduce la animación y ajusta la velocidad
            armatureComponent.animation.Play("frenei", 1);
            armatureComponent.animation.timeScale = 0.5f;
            GetComponent<Rigidbody2D>().AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
            isJumping = true;
        }
        // Si el personaje no está en movimiento, ejecuta la animación "quieto"
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
            isJumping = false;
        }
    }
}
