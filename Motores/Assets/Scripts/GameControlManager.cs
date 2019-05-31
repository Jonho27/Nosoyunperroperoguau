﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlManager : MonoBehaviour
{
    public static bool abrirPuerta, objetoCogido, mochila, cartera;    
    GameObject player;
    GameObject door;
    bool activo;

    public AudioClip sound, open, close, digital;
    AudioSource fuenteAudio;
    


    void Awake()
    {
        abrirPuerta = false;
        activo = false;
        fuenteAudio = GetComponent<AudioSource> ();

        objetoCogido = false;
        mochila = false;
        cartera = false;
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        door = GameObject.FindGameObjectWithTag("Door");
        
        if (objetoCogido == true){
            soundObject();
            objetoCogido = false;
        }

        if (Input.GetKey(KeyCode.Space) == true && abrirPuerta == true && activo == true){
            door.transform.Rotate(0,-90,0);
            fuenteAudio.clip=open;
            fuenteAudio.Play();
            abrirPuerta = false;
        }
    }

    void OnTriggerEnter(Collider other){
       if (other.gameObject == player){
           activo=true;
        }
    }

    void OnTriggerExit(Collider other){
        activo=false;
    }

    public void soundObject(){

        fuenteAudio.clip=sound;
        fuenteAudio.Play();
    }

    /*public void sonidoDigital(){

        fuenteAudio.clip=digital;
        fuenteAudio.Play();
    }*/
}
