using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GoodEndingHandler : MonoBehaviour
{
    // Start is called before the first frame update

    void Start(){
        FindObjectOfType<AudioManager>().Play("YournameAudio");
    }

    public void PlayGameAgain(){
        FindObjectOfType<AudioManager>().StopPlaying("YournameAudio");
        SceneManager.LoadScene("SampleScene");

    }
    public void QuitGameFromGoodEnding(){
        Debug.Log("Quit!");
        Application.Quit();
    }

}
