using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour
{
    // Start is called before the first frame update
   
    void Start()
    {
        
    }

    // Update is called once per frame
    public float speed = 10.0f; // Velocidad de movimiento
    public float jumpForce = 5.0f; // Fuerza de salto
    private bool isJumping = false; // Variable para controlar el salto

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(movimientoHorizontal, 0, 0);

        // Comprueba si el jugador está en el suelo y si se ha presionado la tecla de salto
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    // Este método se llama cuando tu personaje colisiona con otro objeto
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprueba si el personaje está tocando el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
