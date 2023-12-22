using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminaBloque : MonoBehaviour
{
    private int contadorColisiones = 0;
    private string[] colores = { "#7400FF", "#C52CBA", "#323E48", "#0F6BB9" };
    private int maxColisiones = 3;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent <SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kunais"))
        {
            contadorColisiones++;

            if (contadorColisiones < 3)
            {
                DegradarColor(spriteRenderer.color);
            }
            else
            {
                ControlJuego controlJuego = FindObjectOfType<ControlJuego>();
                if (controlJuego != null)
                {
                    string nombreSprite = spriteRenderer.sprite.name;
                    Debug.Log(nombreSprite);

                    // Llama a diferentes métodos dependiendo del nombre del sprite
                    switch (nombreSprite)
                    {
                        case "maMorado1":
                            controlJuego.IncrementarBloquesDestruidosMorado();
                            break;
                        case "maAzul1":
                            controlJuego.IncrementarBloquesDestruidosAzul();
                            break;
                        case "maRosa1":
                            controlJuego.IncrementarBloquesDestruidosRosado();
                            break;
                        case "maNegro1":
                            controlJuego.IncrementarBloquesDestruidosNegro();
                            break;
                            // Agrega más casos para otros nombres de sprites si es necesario
                    }
                }

                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }

    private void DegradarColor(Color colorOriginal)
    {
        float t = (float)contadorColisiones / maxColisiones; // Interpolación lineal
        spriteRenderer.color = Color.Lerp(colorOriginal, Color.black, t); // Degradar hacia negro
    }

    // Convierte un color a su representación hexadecimal
    private string ColorToHex(Color color)
    {
        Color32 color32 = (Color32)color;
        return "#" + color32.r.ToString("X2") + color32.g.ToString("X2") + color32.b.ToString("X2");
    }
}
