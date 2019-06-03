using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoimientoCamara : MonoBehaviour {

    public Transform objetivo;
    public float suavidad = 5f;

    public static bool zoom;

    Vector3 offset;
    Vector3 targetCamPos

    void Start()
    {
        offset = transform.position - objetivo.position;
        zoom = false;
    }

    void FixedUpdate()
    {
        targetCamPos = objetivo.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, suavidad + Time.deltaTime);

        if (zoom == true){
            objetivo = GameObject.FindGameObjectWithTag("Enemigo").transform;
            targetCamPos = objetivo.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, suavidad + Time.deltaTime);
            
        }
    }

}
