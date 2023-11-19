using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portao : MonoBehaviour
{
    public CapsuleCollider2D capsuleCollider;
    public BoxCollider2D portaCol;
    public Animator portaoAnim;
    public Animator botaoAnim;
    public GameObject botao;
    private bool isOpen;
    public bool onCol = false;
    private void Start()
    {
        isOpen = false;
    }
    private void Update()
    {
        if(onCol)
        {
            Abrir();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isOpen )
        {
            botao.SetActive(true);
            onCol = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            botao.SetActive(false);
            onCol = false;
        }
    }
    public void Abrir()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            portaoAnim.SetBool("Abrindo",true);
            botao.SetActive(false);
            capsuleCollider.isTrigger = true;
            isOpen = true;
        }
    }
}
