using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text;
using System;
using UnityEngine.SceneManagement;


public class DialogueManager : MonoBehaviour
{

    public GameObject thisPanel;
    public GameObject nextPanel;
    public String nextScene;
    
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences = new Queue<string>();
    private Image[] images;
    private bool sentenceComplete;
    private string sentence;
    private Dictionary<string, Image> sentencesAndImages = new Dictionary<string, Image>();

    public void StartDialogue(Dialogue dialogue)
    {
        // Start playing dialogue music if it has been instatiated
        try
        {
            GameObject.FindGameObjectWithTag("DialogueMusic").GetComponent<DialogueMusicController>().PlayMusic();
        }
        catch (NullReferenceException)
        {
        }
        //Make sure queue is cleared of sentences
        sentences.Clear();

        //Add each sentence in script to the queue
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

            //Add sentence & corresponding image to dictionary
            sentencesAndImages.Add(sentence, dialogue.images[Array.IndexOf(dialogue.sentences, sentence)]);
        }

        images = dialogue.images;

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
            //Hide all images
            foreach (Image image in images)
            {
                if (image != null)
                {
                    image.enabled = false;
                }
            }
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

        //Display new image
        Image image;
        sentencesAndImages.TryGetValue(sentence, out image);
        if (image != null)
        {
            image.enabled = true;
        }

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

    // Called after the last dialogue scene to change to the next game object within the scene
    // or to another scene.
    private void EndDialogue()
    {
        // Close current active panel
        thisPanel.SetActive(false);

        if (nextScene==null || nextScene=="")
        {
            // Change to next specified panel
            nextPanel.SetActive(true);
        }
        else
        {
            // Change to the next specified scene
            SceneManager.LoadScene(nextScene);
        }
    }
}
