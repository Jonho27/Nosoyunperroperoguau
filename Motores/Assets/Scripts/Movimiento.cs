using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {


    public float velocidad = 6f;

    Vector3 movimiento;//contiene la x, y, z del personaje
    Rigidbody playerRigidbody;
    Animator anim;
    int floorMask;
    float camRayLength = 100f;


    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();

    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");//input para la tecla de movimiento en x
        float v = Input.GetAxisRaw("Vertical");//input para la tecla de movimiento en z

        Move(h, v);
        Turning();
        Animating(h, v);

    }

    void Move(float h, float v)
    {

        movimiento.Set(h, 0f, v);//asigna las teclas pulsadas al vector posición del personaje
        movimiento = movimiento.normalized * velocidad * Time.deltaTime;//normaliza el vector para que al ir en diagonal no se tenga ventaja
        playerRigidbody.MovePosition(transform.position + movimiento);//actualiza la posición del personaje según lo que se ha tecleado

    }

    void Turning()
    {

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }

    }



    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("isWalking", walking);
    }
}
