using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    public GameObject dialogueBox;
    public Image profile;
    public TMP_Text speechText;
    public TMP_Text actorNameText;


    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    public int index = 0;
    public bool onDialogue = false;
    public void Speech(Sprite p, string[] txt, string actorName)
    {
        onDialogue = true;
        dialogueObj.SetActive(true);
        dialogueBox.SetActive(false);
        profile.sprite = p;
        sentences = txt; 
        actorNameText.text = actorName;
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            speechText.text = sentences[index].ToString();
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void NextSentences()
    {
        
        if (speechText.text == sentences[index])
        {
            //ainda tem texto
            if (index < sentences.Length - 1)
            {
                index++;
                
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                onDialogue = false;
                speechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                dialogueBox.SetActive(true);
            }
            
        }
    }
    
}
