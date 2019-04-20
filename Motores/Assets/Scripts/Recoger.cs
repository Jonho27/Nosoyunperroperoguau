using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoger : MonoBehaviour
{
    public bool key = false;
    public bool tieneLlave = false;

   void Update(){
       if (Input.GetKey(KeyCode.Space) && key == true){
            //print("space key was pressed");
            Destroy(gameObject);
            tieneLlave = true;
            }
   }

   void OnTriggerEnter(Collider Personaje){
       if (Personaje.CompareTag("FPS")){
           print("Dentro");
           key = true;
        }
    }

    void OnTriggerExit(Collider Personaje){
       if (Personaje.CompareTag("FPS")){
           print("Fuera");
           key = false;
        }
    }
}
