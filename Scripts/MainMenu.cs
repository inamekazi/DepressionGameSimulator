using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start() {
        FindObjectOfType<AudioManager>().Play("LoginTrack");
    }

    public void PlayGame(){
        FindObjectOfType<AudioManager>().StopPlaying("LoginTrack");
        SceneManager.LoadScene("CarCrashScene");

    }
    public void QuitGame(){
        Debug.Log("Quit!");
        Application.Quit();
    }

}
