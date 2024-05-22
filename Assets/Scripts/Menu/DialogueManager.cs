using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;
    public GameObject waves;
    public GameObject fon;
    public Base baseSctipt;
    private Animator boxAnim;
    public Animator startAnim;
    private Queue<string> sentences;

    private void Start()
    {
        sentences = new Queue<string>();
        boxAnim = dialogueBox.GetComponent<Animator>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
        startAnim.SetTrigger("StartClose");
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
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
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue()
    {
        boxAnim.SetTrigger("DialogueClose");
        waves.SetActive(true);
        Invoke("RemoveDialodue", 1);
        baseSctipt = baseSctipt.GetComponent<Base>();
        baseSctipt.enabled = true;
    }
    public void RemoveDialodue()
    {
        fon.SetActive(false);
    }
}
