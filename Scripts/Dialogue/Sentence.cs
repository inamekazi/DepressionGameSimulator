using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Essentially the node object that forms the dialog tree structure

[CreateAssetMenu(fileName = "NewSentence", menuName="Dialogue/Sentence")]
public class Sentence : ScriptableObject
{
    [TextArea(3, 10)]
    public string text = "text";

    //TODO: if you want the character to have audio rather than text, you could have an AudioClip variable associated with each sentence.
    // your dialoguemanager would then need an audiomixer or audiosource component to play the clips

    public Sentence nextSentence;
    public List<Choice> options = new List<Choice>();

    
    public GameEvent onSpeak;
    public bool HasOptions(){
        if (options.Count == 0){
            return false;
        }
        else {
            return true;
        }
    }

    
    
    
}

[System.Serializable]
public class Choice{
    // public UnityEvent actionVitalsResponse;
    public string text;
    public Sentence nextSentence;
    public GameEvent onOptionSelected;
    public int score;
}
