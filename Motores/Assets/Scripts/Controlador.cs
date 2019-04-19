using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    public int cantidadRecogida = 0;

    public void RecogerObjeto(int cantidad){

        cantidadRecogida += cantidad;


    }
}
