using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoimientoCamara : MonoBehaviour {

    public Transform objetivo;
    public float suavidad = 5f;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - objetivo.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = objetivo.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, suavidad + Time.deltaTime);
    }
}
