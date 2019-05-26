using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerMochila : MonoBehaviour
{
    GameObject player, mochila;
    GameControlManager game;
    bool activo;

    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
        mochila = GameObject.FindGameObjectWithTag("Collectable");
        activo = false;
        game = new GameControlManager();
    }

   void Update(){
        mochila.transform.Rotate(0,-1,0);
        if (Input.GetKeyDown(KeyCode.Space) == true && activo == true){
            GameControlManager.mochila = true;
            GameControlManager.objetoCogido = true;
            Destroy(mochila);
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
