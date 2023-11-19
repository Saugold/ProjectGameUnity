using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string[] speechText;
    public string actorName;
    public LayerMask playerLayer;
    public float radious;
    public DialogueControl dc;
    private bool onRadious;
    

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Interact();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)&&onRadious)
        {
            dc.Speech(profile, speechText, actorName);
        }
        if(Input.GetKeyDown(KeyCode.S) && dc.onDialogue)
        {
            dc.NextSentences();
        }
    }
    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);
        
        if( hit != null )
        {
            onRadious = true;
        }
        else
            onRadious = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}
