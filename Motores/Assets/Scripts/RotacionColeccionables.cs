using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionColeccionables : MonoBehaviour
{   

    GameObject coleccionable;
    // Start is called before the first frame update
    void Start()
    {
     coleccionable = GameObject.FindGameObjectWithTag("Collectable");   
    }

    // Update is called once per frame
    void Update()
    {
        coleccionable.transform.Rotate(0,-1,0);
    }
}
