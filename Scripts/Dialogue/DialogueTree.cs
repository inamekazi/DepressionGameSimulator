using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="NewDialogueTree", menuName="Dialogue/Dialogue Tree")]
public class DialogueTree : ScriptableObject
{
    [Tooltip("The name of the character speaking the dialogue")]
    public string charactersName;
    
    public Sentence startingSentence; // root node
}
