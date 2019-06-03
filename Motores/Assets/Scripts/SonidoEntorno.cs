using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoEntorno : MonoBehaviour
{
    GameObject player, entorno;
    GameControlManager game;
    bool activo;

    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
        entorno = GameObject.FindGameObjectWithTag("entorno");
        activo = false;
        game = new GameControlManager();
    }

   void Update(){
        
        if (Input.GetKeyDown(KeyCode.Space) == true && activo == true){
            GameControlManager.sonar = true;
        }
   }

   void OnTriggerEnter(Collider other){
       if (other.gameObject == player){
           activo = true;        }
    }

    void OnTriggerExit(Collider other){
       if (other.gameObject == player){
           activo = false;
        }
    }
}
