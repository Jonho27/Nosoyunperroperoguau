using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public Image monedero;
    public Image mochila;
    public Image llave;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControlManager.cartera == true)
        {
            monedero.color = new Color32(255, 255, 225, 255);
        }

        if (GameControlManager.mochila == true)
        {
            mochila.color = new Color32(255, 255, 225, 255);
        }

        if (GameControlManager.abrirPuerta == true)
        {
            llave.color = new Color32(255, 255, 225, 255);
        }

    }
}
