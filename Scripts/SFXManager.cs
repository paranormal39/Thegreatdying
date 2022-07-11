using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource audiosource;

    public AudioClip[] Orcsounds;

    public AudioClip manapot,firehit,gethit,gold,healthpot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void randomorcsound(){
        int random = Random.Range(0,Orcsounds.Length);

         if(!audiosource.isPlaying){
        audiosource.PlayOneShot(Orcsounds[random]);
        }
    }

    public void manapickup(){

        if(!audiosource.isPlaying){
            audiosource.PlayOneShot(manapot);
        }
    }

    public void firehitsfx(){
        if(!audiosource.isPlaying){
            audiosource.PlayOneShot(firehit);
        }
    }

    public void gethitsfx(){
        if(!audiosource.isPlaying){
            audiosource.PlayOneShot(gethit);
        }
    }

    public void getgold(){
        if(!audiosource.isPlaying){
            audiosource.PlayOneShot(gold);
        }
        
    }

    public void healthpick(){
        if(!audiosource.isPlaying){
            audiosource.PlayOneShot(healthpot);
        }
    }
}
