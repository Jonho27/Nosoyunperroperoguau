using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {


    public float velocidad = 6f;

    Vector3 movimiento;//contiene la x, y, z del personaje
    Rigidbody playerRigidbody;


    void Awake()
    {

        playerRigidbody = GetComponent<Rigidbody>();

    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");//input para la tecla de movimiento en x
        float v = Input.GetAxisRaw("Vertical");//input para la tecla de movimiento en z

        Move(h, v);

      
    }

    void Move(float h, float v)
    {
        movimiento.Set(h, 0f, v);//asigna las teclas pulsadas al vector posición del personaje
        movimiento = movimiento.normalized * velocidad * Time.deltaTime;//normaliza el vector para que al ir en diagonal no se tenga ventaja
        playerRigidbody.MovePosition(transform.position + movimiento);//actualiza la posición del personaje según lo que se ha tecleado
    }
}
