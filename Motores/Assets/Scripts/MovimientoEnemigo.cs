using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoEnemigo : MonoBehaviour
{

    private VistaEnemigo vistaEnemigo;
    private Animator anim;
    UnityEngine.AI.NavMeshAgent nav;
    //private bool alcanzado1;
    //private bool alcanzado2;
    //Vector3 posicion1 = new Vector3(55.4f, 0.5f, 177);
    //Vector3 posicion2 = new Vector3(65.2f, 0.5f, 62.8f);

    public float patrolWaitTime = 0.5f;
    public Transform[] puntosRuta;
    private float patrolTimer;
    private int puntosRutaIndex;


    public bool HOLA;
    private float pillado;

    void Awake()
    {
        vistaEnemigo = GetComponent<VistaEnemigo>();
        anim = GetComponent<Animator>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // alcanzado1 = false;
        //alcanzado2 = true;
        puntosRutaIndex = 0;


        HOLA = false;
        pillado = 0;


    }

    void Update()
    {

        if (vistaEnemigo.playerInSight == false && EnemyManager.visto == false)
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

        else if (EnemyManager.visto == true && vistaEnemigo.playerInSight == false) //AÑADIDO POR JORGE PARA EL ABUELO
        {
            HOLA = true;
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

            /*anim.SetBool("isWalking", true);
            nav.destination = puntosRuta[puntosRutaIndex].position;*/
        }

        else
        {
            pillado += Time.deltaTime;
            nav.speed = 0f;
            anim.SetBool("isWalking", false);

            if(pillado >= 3f)
            {
                //Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            

        }



        /*if(alcanzado1 == false) //CON DISTANCE PARA COMPROBAR SI EL ENEMIGO SE ENCUENTRA A CIERTA DISTANCIA DE SU DESTINO
        {
            anim.SetBool("isWalking", true);
            nav.SetDestination(posicion1);
            if(transform.position == posicion1)
            {
                alcanzado1 = true;
                alcanzado2 = false;
            }

        }

        if (alcanzado2 == false)
        {
            anim.SetBool("isWalking", true);
            nav.SetDestination(posicion2);
            if (transform.position == posicion2)
            {
                alcanzado2 = true;
                alcanzado1 = false;
            }

        }*/


    }
}
