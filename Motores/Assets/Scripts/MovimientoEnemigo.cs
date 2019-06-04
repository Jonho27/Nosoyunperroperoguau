using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoEnemigo : MonoBehaviour
{

    private VistaEnemigo vistaEnemigo;
    private Animator anim;
    UnityEngine.AI.NavMeshAgent nav;

    public float patrolWaitTime = 0.5f;
    public Transform[] puntosRuta;
    private float patrolTimer;
    private int puntosRutaIndex;
    private float pillado;


    void Awake()
    {
        vistaEnemigo = GetComponent<VistaEnemigo>();
        anim = GetComponent<Animator>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

        puntosRutaIndex = 0;
        pillado = 0;


    }

    void Update()
    {

        if (vistaEnemigo.playerInSight == false && EnemyManager.visto == false)
        {

            nav.speed = 4.5f;

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

        else if (EnemyManager.visto == true && vistaEnemigo.playerInSight == false) //AÑADIDO POR JORGE PARA EL ABUELO
        {
     
            nav.destination = EnemyManager.utimaPosicion;

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
                    EnemyManager.visto = false;
                    nav.destination = puntosRuta[puntosRutaIndex].position;
                }
            }

            else
                patrolTimer = 0f;

        }

        else
        {
            MoimientoCamara.zoom = true;
            pillado += Time.deltaTime;
            nav.speed = 0f;
            anim.SetBool("isWalking", false);

            if(pillado >= 2f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            

        }

    }
}
