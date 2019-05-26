using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerCartera : MonoBehaviour
{
    GameObject player, cartera;
    GameControlManager game;
    bool activo;

    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
        cartera = GameObject.FindGameObjectWithTag("Collectable1");
        activo = false;
        game = new GameControlManager();
    }

   void Update(){
        cartera.transform.Rotate(0,-1,0);
        if (Input.GetKeyDown(KeyCode.Space) == true && activo == true){
            GameControlManager.mochila = true;
            GameControlManager.objetoCogido = true;
            Destroy(cartera);
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
