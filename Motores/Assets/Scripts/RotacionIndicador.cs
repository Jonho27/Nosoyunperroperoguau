using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionIndicador : MonoBehaviour
{
    GameObject alerta, alerta1, alerta2;
    GameControlManager game;
    bool activo1,activo2,activo3;

    // Start is called before the first frame update
    void Start()
    {
        game = new GameControlManager();
        alerta = GameObject.FindGameObjectWithTag("alert");
        alerta1 = GameObject.FindGameObjectWithTag("alert1");
        alerta2 = GameObject.FindGameObjectWithTag("alert2");
        activo1 = true;
        activo2 = true;
        activo3 = true;

    }

    // Update is called once per frame
    void Update()
    {

        if(GameControlManager.cartera == true && activo1 == true){
            Destroy(alerta);
            activo1 = false;
        }
        else if (activo1 != false){alerta.transform.Rotate(0,-1,0);}
        if(GameControlManager.abrirPuerta == true&& activo2 == true){
            Destroy(alerta1);
            activo2 = false;
        }
        else if (activo2 != false){alerta1.transform.Rotate(0,-1,0);}
        if(GameControlManager.mochila == true && activo3 == true){
            Destroy(alerta2);
            activo3 = false;
        }
        else if (activo3 != false){alerta2.transform.Rotate(0,-1,0);}
        
    }
    void changePosition(GameObject x){
        Debug.Log("YES");
        x.transform.position = new Vector3(0f,-10f,0f);
    }

}
