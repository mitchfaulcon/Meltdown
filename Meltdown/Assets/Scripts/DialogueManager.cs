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
    private bool sentenceComplete;
    private string sentence;

    public void StartDialogue(Dialogue dialogue)
    {
        //Make sure queue is cleared of sentences
        sentences.Clear();

        //Add each sentence in script to the queue
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        sentenceComplete = true; //Set to true intially so first sentence starts straight away
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //End the dialogue if there are no sentences remaining and if the sentence has been fully typed out
        if (sentences.Count == 0 && sentenceComplete)
        {
            EndDialogue();
            return;
        }

        StopAllCoroutines(); //Stop the sentence from 'typing'

        //Check if the sentence has finished typing
        if (sentenceComplete)
        {
            //Start displaying the next sentence
            sentence = sentences.Dequeue();
            StartCoroutine(TypeSentence(sentence));
        } else
        {
            //Show the full uncompleted sentence
            dialogueText.text = sentence;
            sentenceComplete = true;
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        sentenceComplete = false;

        //Type the script one character at a time
        StringBuilder sb = new StringBuilder("");
        dialogueText.text = sb.ToString();
        foreach(char character in sentence.ToCharArray())
        {
            sb.Append(character);
            dialogueText.text = sb.ToString();
            yield return new WaitForSeconds(0.03f);
        }

        sentenceComplete = true;
    }

    private void EndDialogue()
    {
        //Change active panel to next one
        thisPanel.SetActive(false);
        nextPanel.SetActive(true);
    }
}
