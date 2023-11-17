using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brazoDerecho : MonoBehaviour
{
    public Transform Kunai;
    public SpriteRenderer KunaiSR;
    public int speedball;
    public GameObject kunaiPrefab;
    Vector3 finaltarget;
    public float maxRotationAngle = 40f; // Ángulo máximo de rotación de la mano
    private Quaternion initialRotation;
    private Vector3 initialPosition;
    Vector3 targetRotation;


    // Start is called before the first frame update
    void Start()
    {
        // Guarda la rotación y posición inicial del brazo
        initialRotation = Kunai.rotation;
        initialPosition = Kunai.position;
    }

    // Update is called once per frame
    void Update()
    {/*
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
        */

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot();
        
    }
    void Shoot()
    {
        var Ball = Instantiate(kunaiPrefab, Kunai.position, transform.rotation, transform.parent);
        targetRotation.z = 0;
        finaltarget = (targetRotation - transform.position).normalized;
        // Utiliza la función AddForce para aplicar una fuerza al objeto Ball
        Ball.GetComponent<Rigidbody2D>().AddForce(finaltarget * speedball, ForceMode2D.Impulse);
        // Destruye el objeto Ball después de 3 segundos
        Destroy(Ball, 3.0f);
    }

}
