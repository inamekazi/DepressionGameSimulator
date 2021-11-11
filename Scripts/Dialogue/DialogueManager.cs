using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;



using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

// Based on https://www.youtube.com/watch?v=_nRzoTzeyxU&list=PLqOe2mUJ7svbSaopX9bIprz4uGnt4lBhw&index=31 and https://github.com/LeiQiaoZhi/UnityDialogueSystem

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameUIText;
    public TextMeshProUGUI dialogueUIText;
    public Canvas dialogueCanvas;
    public GameObject continueButton;
    public GameObject optionsPanel;
    public TextMeshProUGUI[] optionsUI;

    private DialogueTree dialogue;
    private Sentence currentSentence = null;

    
    
    public int totalScore;


    public void StartDialog(DialogueTree dialogueTree){
        dialogueCanvas.enabled = true;
        nameUIText.text = dialogueTree.charactersName;
        dialogue = dialogueTree;
        currentSentence = dialogue.startingSentence;
        totalScore = 0;
        DisplaySentence();
    }

    public void AdvanceSentence(){
        if (currentSentence.nextSentence == null){
            EndDialogue();
            return;
        }
        else{
            currentSentence = currentSentence.nextSentence;
            DisplaySentence();
        }
    }

    public void DisplaySentence(){
        if (currentSentence == null){
            EndDialogue();
            return;
        }
        HideOptions();

        string sentence = currentSentence.text;
        //dialogueUIText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence){
        dialogueUIText.text = "";
        foreach(char letter in sentence.ToCharArray()){
            dialogueUIText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        if (currentSentence.HasOptions()){
           DisplayOptions();
        }
        else {
            continueButton.SetActive(true);
        }
    }

    void DisplayOptions(){
        if (currentSentence.options.Count <= optionsUI.Length){
            for(int i=0; i < currentSentence.options.Count; i++){
                optionsUI[i].text = currentSentence.options[i].text;
                optionsUI[i].transform.parent.gameObject.SetActive(true);
            }
        }
        optionsPanel.SetActive(true);
    }

    void HideOptions(){
        continueButton.SetActive(false);

        foreach(TextMeshProUGUI option in optionsUI){
            option.transform.parent.gameObject.SetActive(false);

        }
        optionsPanel.SetActive(false);

    }

    public void EndDialogue(){
        Debug.Log("dialogue ended");
        dialogueCanvas.enabled = false;
        totalScore = 0;
    }

    // Called from the option button onClick handlers, the index passed in is based on the button that was pressed
    public void OptionOnClick(int index){
        // if (currentSentence != null){
            Choice option = currentSentence.options[index];
            if (option.onOptionSelected != null){
                option.onOptionSelected.Raise();
            }
            // option.actionVitalsResponse.Invoke();
            currentSentence = option.nextSentence;
            totalScore = totalScore + option.score;
            print(option.score);
            print(totalScore);
            DisplaySentence();
        // }
    //     else{
    //         EndDialogue();
    //     }
    }

    public void ChangeSanity(Slider slider){
      slider.value += totalScore;
    }

    public void EndGame(Slider slider){
        if (slider.value >= 50){
          FindObjectOfType<AudioManager>().StopPlaying("PianoTheme");
          SceneManager.LoadScene("GoodEndSce");
        }
        else{
          FindObjectOfType<AudioManager>().StopPlaying("PianoTheme");
          SceneManager.LoadScene("BadEndScene");
        }
    }
}
