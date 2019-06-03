using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoimientoCamara : MonoBehaviour {

    public Transform objetivo;
    public float suavidad = 5f;

    public static bool zoom;

    Vector3 offset;
    Vector3 targetCamPos;
    GameObject camaraZoom;

    private float initHeightAtDist;
    private bool dzEnabled;

    float time;

    Camera camara;

    void Awake()
    {
        offset = transform.position - objetivo.position;
        zoom = false;
        //camaraZoom.transform.localPosition = new Vector3(0, 5.6f, 0);
        camara = GetComponent<Camera>();

        time = 0;
    }

    void FixedUpdate()
    {
        targetCamPos = objetivo.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, suavidad + Time.deltaTime);

        if (zoom == true){
            objetivo = GameObject.FindGameObjectWithTag("Enemigo").transform;
            targetCamPos = objetivo.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, suavidad + Time.deltaTime);

            if(time >= 0.005)
            {
                camara.orthographicSize -= 1.0f;
                time = 0;

                if(camara.orthographicSize <= 7.0f)
                {
                    camara.orthographicSize = 7.0f;

                }

            }

        }
    }

    void Update()
    {
        time += Time.deltaTime;

    }


}
