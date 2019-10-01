using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;

    public TextMeshProUGUI dialogueText;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
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
        Debug.Log("end of conversation");
    }
}
