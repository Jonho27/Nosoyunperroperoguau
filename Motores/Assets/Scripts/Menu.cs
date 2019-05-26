using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }

    public void Instrucciones()
    {
        SceneManager.LoadScene(2);
    }

    public void Volver()
    {
        SceneManager.LoadScene(0);
    }
}
