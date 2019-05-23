using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public static bool visto;
    public static Vector3 utimaPosicion;

    public bool visto2;
    // Start is called before the first frame update
    void Start()
    {

        visto = false;
        visto2 = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (visto == true)
            visto2 = true;

        else
            visto2 = false;
        
    }
}
