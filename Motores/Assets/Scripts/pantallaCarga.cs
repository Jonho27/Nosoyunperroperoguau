using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pantallaCarga : MonoBehaviour
{
    private float timer = 0.0f;
    GameObject pantalla;

    void Start()
    {
        pantalla = GameObject.FindGameObjectWithTag("pantallaCarga");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        

    }

    void FixedUpdate(){

        if (timer >1)
        {
            pantalla.GetComponent<Image>().color = new Color32(42, 42, 43, 0);    
        }

        if (timer >4)
        {
            pantalla.GetComponent<Image>().color = new Color32(42, 42, 43, 255);    
        }

        if (timer >5)
        {
            SceneManager.LoadScene(0);
        }

    }
}
