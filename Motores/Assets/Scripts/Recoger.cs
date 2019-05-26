using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoger : MonoBehaviour
{
    public bool tieneLlave;
    bool activo;
    GameObject player, key;
    GameManager game;

    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player");
        key = GameObject.FindGameObjectWithTag("Key");
        tieneLlave = false;
        activo = false;
    }

   void Update(){
        if (Input.GetKey(KeyCode.Space) == true && activo == true){
            tieneLlave = true;
            GameManager.abrirPuerta = true;
            Destroy(key);
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

       