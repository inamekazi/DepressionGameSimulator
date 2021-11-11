using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    public static AudioManager instance;
    void Awake()
    {
    //    if(instance == null){
    //         instance = this;
    //     }
    //     else{
    //         Destroy(gameObject);
    //         return;
    //     }
    //     DontDestroyOnLoad(gameObject); 

        foreach(Sound s in sounds){
           s.source =  gameObject.AddComponent<AudioSource>();
           s.source.clip = s.clip;

           s.source.volume = s.volume;
           s.source.pitch = s.pitch;
           s.source.loop = s.loop;
           s.source.outputAudioMixerGroup = s.group;

        }
    }
    void Start(){
        // Play("LoginTrack");
    }
    public void Play (string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if(s == null){
            return;
        }

        s.source.Play();
    }
    public void StopPlaying(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            return;
        }
        s.source.Stop();
    }

}
