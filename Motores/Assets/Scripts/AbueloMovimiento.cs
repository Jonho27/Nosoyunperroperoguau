using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbueloMovimiento : MonoBehaviour
{
    private VistaAbuelo vistaEnemigo;
    private Animator anim;
    UnityEngine.AI.NavMeshAgent nav;
    //private bool alcanzado1;
    //private bool alcanzado2;
    //Vector3 posicion1 = new Vector3(55.4f, 0.5f, 177);
    //Vector3 posicion2 = new Vector3(65.2f, 0.5f, 62.8f);

    public float patrolWaitTime = 1f;
    public Transform[] puntosRuta;
    private float patrolTimer;
    private int puntosRutaIndex;

    void Awake()
    {
        vistaEnemigo = GetComponent<VistaAbuelo>();
        anim = GetComponent<Animator>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // alcanzado1 = false;
        //alcanzado2 = true;
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
