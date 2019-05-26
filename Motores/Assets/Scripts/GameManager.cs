using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool abrirPuerta;
    GameObject player;
    GameObject door;
    bool activo;
    

    void Awake()
    {
        abrirPuerta = false;
        activo = false;
    }


    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        door = GameObject.FindGameObjectWithTag("Door");
        

        if (Input.GetKey(KeyCode.Space) == true && abrirPuerta == true && activo == true){
            Debug.Log("HOLA");
            door.transform.Rotate(0,-90,0);
            abrirPuerta = false;
        }
        
    }

    void OnTriggerEnter(Collider other){
       if (other.gameObject == player){
           activo=true;
        }
    }

    void OnTriggerExit(Collider other){
        activo=false;
    }
}
