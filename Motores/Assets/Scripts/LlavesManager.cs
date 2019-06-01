using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LlavesManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControlManager.abrirPuerta == true)
        {
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 225, 255);
        }
    }
}
