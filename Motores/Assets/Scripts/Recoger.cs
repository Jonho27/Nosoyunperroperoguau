using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoger : MonoBehaviour
{
   public int cantidad = 1;
   public bool key = false;

   void Update()
    {
        
        if (Input.GetKeyDown("space") && key == true)
        {
            //print("space key was pressed");
            Destroy(gameObject);
        }
    }

   void OnTriggerEnter(Collider Personaje){
       if (Personaje.CompareTag("FPS")){
           Personaje.GetComponent<Controlador>().RecogerObjeto(cantidad);
           key = true;
       }
   }
}
