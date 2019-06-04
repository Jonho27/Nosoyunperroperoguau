using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbueloMovimiento : MonoBehaviour
{
    private VistaAbuelo vistaEnemigo;
    private Animator anim;
    UnityEngine.AI.NavMeshAgent nav;
 

    public float patrolWaitTime = 1f;
    public Transform[] puntosRuta;
    private float patrolTimer;
    private int puntosRutaIndex;

    void Awake()
    {
        vistaEnemigo = GetComponent<VistaAbuelo>();
        anim = GetComponent<Animator>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        puntosRutaIndex = 0;


    }

    void Update()
    {

        if (vistaEnemigo.playerInSight == false)
        {

            nav.speed = 3.5f;

            if (nav.remainingDistance < nav.stoppingDistance)
            {
                anim.SetBool("isWalking", false);
                patrolTimer += Time.deltaTime;
                if (patrolTimer >= patrolWaitTime)
                {
                    anim.SetBool("isWalking", true);
                    if (puntosRutaIndex == puntosRuta.Length - 1)
                        puntosRutaIndex = 0;

                    else
                        puntosRutaIndex++;

                    patrolTimer = 0f;
                }
            }

            else
                patrolTimer = 0f;

            anim.SetBool("isWalking", true);
            nav.destination = puntosRuta[puntosRutaIndex].position;

        }

        else
        {
            nav.speed = 0f;
            anim.SetBool("isWalking", false);

        }
    }

}
