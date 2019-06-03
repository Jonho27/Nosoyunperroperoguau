using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerController : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject player;
    bool activo, sonar;
    float secondsCounter;
    public AudioClip sound;
    AudioSource fuenteAudio;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        activo = false;
        fuenteAudio = GetComponent<AudioSource> ();
        sonar = true;
        secondsCounter=0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activo == true && sonar == true){
            sonar = false;
            victoria();
        }
    }

    void OnTriggerEnter(Collider other){
       if (other.gameObject == player){
           activo = true;
        }
    }

    void OnTriggerExit(Collider other){
       if (other.gameObject == player){
           activo = false;
        }
    }

    void victoria(){
        fuenteAudio.clip=sound;
        fuenteAudio.Play();

        SceneManager.LoadScene(0);

    }
}
