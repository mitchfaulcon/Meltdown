using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class DialogueManager : MonoBehaviour
{

    public GameObject thisPanel;
    public GameObject nextPanel;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences = new Queue<string>();

    public void StartDialogue(Dialogue dialogue)
    {
        //Make sure queue is cleared of sentences
        sentences.Clear();

        //Add each sentence in script to the queue
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //End the dialogue if there are no sentences remaining
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines(); //Ensures the previous sentence does not continue typing if the user presses 'continue' quickly
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        //Type the script one character at a time
        StringBuilder sb = new StringBuilder("");
        dialogueText.text = sb.ToString();
        foreach(char character in sentence.ToCharArray())
        {
            sb.Append(character);
            dialogueText.text = sb.ToString();
            yield return new WaitForSeconds(0.03f);
        }
    }

    private void EndDialogue()
    {
        //Change active panel to next one
        thisPanel.SetActive(false);
        nextPanel.SetActive(true);
    }
}
