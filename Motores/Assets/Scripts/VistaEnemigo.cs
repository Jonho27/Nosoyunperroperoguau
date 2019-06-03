using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VistaEnemigo : MonoBehaviour
{
    public float fieldOfViewAngle = 110f;
    public bool playerInSight;

    private SphereCollider col;
    private Animator anim;
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        col = GetComponent<SphereCollider>();
    }

    void update()
    {
        
    }

    void OnTriggerStay (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInSight = false;
            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if(angle < fieldOfViewAngle * 10)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
                {
                    if(hit.collider.gameObject == player)
                    {
                        playerInSight = true;
                        Movimiento.jugadorPillado = true;
                        //anim.SetBool("isWalking", true);
                    }
                }
            }
        }
    }
}
