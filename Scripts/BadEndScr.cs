using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class BadEndScr : MonoBehaviour
{
    void Start() {
        FindObjectOfType<AudioManager>().Play("PianoRick");
    }

    public void PlayGame(){
        FindObjectOfType<AudioManager>().StopPlaying("PianoRick");
        SceneManager.LoadScene("SampleScene");

    }
    public void QuitGame(){
        Debug.Log("Quit!");
        Application.Quit();
    }
}
