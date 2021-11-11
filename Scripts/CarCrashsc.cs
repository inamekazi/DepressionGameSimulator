using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class CarCrashsc : MonoBehaviour
{
    void Start() {
        FindObjectOfType<AudioManager>().Play("CrashMusic");
    }

    public void NextPanel(){
        FindObjectOfType<AudioManager>().StopPlaying("CrashMusic");
        SceneManager.LoadScene("SampleScene");
    }
}
