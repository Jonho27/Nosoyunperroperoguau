using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InicioManager : MonoBehaviour
{

    public Image image;

    float speed = 1f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 1)
        {
            image.color = Color.Lerp(image.color, Color.clear, speed * Time.deltaTime);
        }

        if(timer >= 4)
        {
            SceneManager.LoadScene(0);
        }

        //image.color = Color.Lerp(image.color, Color.clear, speed * Time.deltaTime);

    }
}
