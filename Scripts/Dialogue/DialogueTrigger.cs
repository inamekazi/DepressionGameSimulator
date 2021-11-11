using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public DialogueTree dialogue;
    // public UnityEvent RestoreSanityByTalk;
    public UnityEvent LockCamera;
    public UnityEvent UnlockCamera;
    public UnityEvent AddScore;

    public Slider sanity;

   


    // Called automatically by unity when a rigid body intersects a collider with "isTrigger" checked.
    public void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
            // RestoreSanityByTalk.Invoke();
            LockCamera.Invoke();
            dialogueManager.StartDialog(dialogue);
        }
    }

    public void OnTriggerExit(Collider other){
        if(other.tag == "Player"){
            UnlockCamera.Invoke();
            AddScore.Invoke();
            dialogueManager.EndDialogue();
            dialogueManager.ChangeSanity(sanity);
            print("sanity = " + sanity.value);
        }
    }
}
