using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Dialogue dialogue;

    private void Start()
    {
        //Start displaying the dialogue when the object with this script gets loaded
        //(after previous panel changes to this one)
        dialogueManager.StartDialogue(dialogue);
    }
}
