using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinnerController : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject player;
    bool activo, sonar, final;
    float secondsCounter;
    public AudioClip sound;
    AudioSource fuenteAudio;

    public Image image;
    Color color = new Color(255f, 255f, 255f, 255f);
    float speed = 0.2f;

    float time;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        activo = false;
        fuenteAudio = GetComponent<AudioSource> ();
        sonar = true;
        secondsCounter=0;
        time = 0;
        final = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(activo == true){
            image.color = Color.Lerp(image.color, color, speed * Time.deltaTime);

            if(sonar == true)
            {
                sonar = false;
                victoria();
            }
            
        }

        if(time >= 2 && final == true)
        {
            SceneManager.LoadScene(0);
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
        time = 0;
        final = true;
    }
}
