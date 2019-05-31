using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoBaño : MonoBehaviour
{
    GameObject player, baño;
    GameControlManager game;
    bool activo;

    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
        baño = GameObject.FindGameObjectWithTag("Baño");
        activo = false;
        game = new GameControlManager();
    }

   void Update(){
        
        if (Input.GetKeyDown(KeyCode.Space) == true && activo == true){
            GameControlManager.sonarBaño = true;
        }
   }

   void OnTriggerEnter(Collider other){
       if (other.gameObject == player){
           activo = true;
        }
    }

    void OnTriggerExit(Collider other){
       if (other.gameObject == player){
           activo = false;
        }
    }
}
