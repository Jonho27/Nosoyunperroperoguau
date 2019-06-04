using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoger : MonoBehaviour
{
    bool activo;
    GameObject player, key;
    GameControlManager game;

    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
        key = GameObject.FindGameObjectWithTag("Key");
        activo = false;
        game = new GameControlManager();
    }

   void Update(){
        key.transform.Rotate(0,-1,0);
        if (Input.GetKeyDown(KeyCode.Space) == true && activo == true){
            GameControlManager.abrirPuerta = true;
            GameControlManager.objetoCogido = true;
            MoimientoCamara.zoomObjeto = 1;
            Destroy(key, 2f);
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

       