using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kunai : MonoBehaviour
{
    public AudioSource audioSource; // Referencia al componente AudioSource
    public AudioClip audioClip; // Referencia al clip de audio

    public Transform Kunai;
    private int tipoKunai;
    public SpriteRenderer KunaiSR;
    public int speedball;
    Vector3 targetRotation;

    public GameObject kunaiPrefab;
    public GameObject kunaiPrefab2;
    Vector3 finaltarget;

    private void Update()
    {
        targetRotation = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(targetRotation.y, targetRotation.x) * Mathf.Rad2Deg;
        Kunai.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        if (angle > 90 || angle < -90)
        {
            KunaiSR.flipY = true;
        }
        else
        {
            KunaiSR.flipY = false;
        }
       
        if (angle >110 && angle <180 || angle >-180 && angle < -133 || angle <70 && angle>0 || angle >-50 && angle <0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
                Shoot(angle);
        }

        
    }


    void Shoot(float angle)
    {
        // Reproduce el audio
        audioSource.PlayOneShot(audioClip);
        Debug.Log(angle);

        if(tipoKunai == 0)
        {
            var Ball = Instantiate(kunaiPrefab, Kunai.position, transform.rotation, transform.parent);


            targetRotation.z = 0;
            finaltarget = (targetRotation - transform.position).normalized;
            // Utiliza la función AddForce para aplicar una fuerza al objeto Ball
            Ball.GetComponent<Rigidbody2D>().AddForce(finaltarget * speedball, ForceMode2D.Impulse);
            // Destruye el objeto Ball después de 3 segundos
            Destroy(Ball, 3.0f);
        }else if(tipoKunai == 1)
        {
             var Ball = Instantiate(kunaiPrefab2, Kunai.position, transform.rotation, transform.parent);


            targetRotation.z = 0;
            finaltarget = (targetRotation - transform.position).normalized;
            // Utiliza la función AddForce para aplicar una fuerza al objeto Ball
            Ball.GetComponent<Rigidbody2D>().AddForce(finaltarget * speedball, ForceMode2D.Impulse);
            // Destruye el objeto Ball después de 3 segundos
            Destroy(Ball, 3.0f);
        }
       
    }

    public void CambiarKunaiDos()
    {
       tipoKunai = 1;
    }   
    public void CambiarKunaiUno()
    {
        tipoKunai = 0;
    }

}
