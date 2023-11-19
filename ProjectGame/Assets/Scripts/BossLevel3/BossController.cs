using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.Windows;
using System.Xml.Serialization;

public class BossController : MonoBehaviour
{
    public Transform player;
    public float velocidade;
    public float velparado = 0f;
    public float velNormal = 10f;
    public Rigidbody2D bossRig;
    public BoxCollider2D bossVisao;
    public BoxCollider2D ataquePertoCol;
    public BoxCollider2D spellCol;
    public BossAnim bossAnim;
    public bool isAtaque;
    public bool isClose;
    public LifeSystem Life;
    public Rigidbody2D playerBody;
    public Rigidbody2D head;
    public float distanciaEntreRaios;
    public GameObject spell;
    public float intervaloAtaques = 5f;
    public float alturaDoRaioAcima = 2.0f;
    public bool atacando = true;
    private SpriteRenderer sprite;
    private void Update()
    {
        if(velocidade != velparado)
        {
            bossAnim.bossAnimator.SetBool("isIdle", false);
        }
        //vira o sprite
        
        //-----------------------------
        if (velocidade > 1)
        {
            bossAnim.Walk(true);
        }
        else if(velocidade == velparado)
        {
            bossAnim.Walk(false);
            bossAnim.bossAnimator.SetBool("isIdle", true);
        }

        //SeguirPlayer();

        if(atacando == false)
        {
            CancelInvoke("AtackRandom");
            
            
        }


    }
    void Start()
    {


        sprite = GetComponent<SpriteRenderer>();    
        velocidade = velparado;
        isAtaque = false;
        bossAnim = GetComponent<BossAnim>();
        bossRig = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("AtackRandom", 0f, 3f);
    }
    private void SeguirPlayer()
    {
        if (player != null && isAtaque == false)
        {
            
            Vector2 direcao = (Vector2)player.position - bossRig.position;
            direcao.Normalize();
            VirarSprite(direcao.x);
            bossRig.MovePosition(bossRig.position + direcao * velocidade * Time.deltaTime);
        }
    }
    void VirarSprite(float direcao)
    {
        Vector3 escala = transform.localScale;

        if (direcao > 0)
            escala.x = Mathf.Abs(escala.x) * -1f;
        else if (direcao < 0)
            escala.x = Mathf.Abs(escala.x);

        transform.localScale = escala;
    }
    //-----------ATAQUE PERTO---------------//
    IEnumerator AtaquePerto()
    {

        if (isClose) 
        { 
            isAtaque = true;
            bossAnim.AnimAtack1();
            if (isAtaque == false)
            {
                velocidade = velNormal;
            }
            else
                velocidade = velparado;
            if (OnAtaqueArea())
            {
                intervaloAtaques = 3f;
                Debug.Log("tomou");
                playerBody.velocity += new Vector2(0f, 15f);
                Life.life = Life.life - 3;
                GameController.instance.TomarDano();
            }
            yield return new WaitForSeconds(1f);
            bossAnim.bossAnimator.ResetTrigger("isAtaque1");
           
            isAtaque = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isClose = true;
            if (isClose == true && atacando == true)
            {
                StartCoroutine(AtaquePerto());
            }
        }
    }
    public bool OnAtaqueArea()
    {
        return ataquePertoCol.IsTouchingLayers(LayerMask.GetMask("Player"));


    }

    //----------------------------------------------------------//

    //---------------SPELLL------------------------//
    IEnumerator AtivarPoder()
    {
        Vector3 posicaoPlayer = player.position;
        
            if (player != null)
            {
                bossAnim.AnimAtack2();
                yield return new WaitForSeconds(0.8f);
            // Raio na posição do jogador
            Vector3 posicaoDoRaioJogador = new Vector3(posicaoPlayer.x, posicaoPlayer.y + alturaDoRaioAcima, posicaoPlayer.z);
            GameObject raioJogador = Instantiate(spell, posicaoDoRaioJogador, Quaternion.identity);

            // Raio à direita do jogador
            Vector3 posicaoDoRaioDireita = new Vector3(posicaoPlayer.x + distanciaEntreRaios, posicaoPlayer.y + alturaDoRaioAcima, posicaoPlayer.z);
            GameObject raioDireita = Instantiate(spell, posicaoDoRaioDireita, Quaternion.identity);

            // Raio à esquerda do jogador
            Vector3 posicaoDoRaioEsquerda = new Vector3(posicaoPlayer.x - distanciaEntreRaios, posicaoPlayer.y + alturaDoRaioAcima, posicaoPlayer.z);
            GameObject raioEsquerda = Instantiate(spell, posicaoDoRaioEsquerda, Quaternion.identity);
            //Destroi a Instancia
            Destroy(raioJogador, 1.6f);
            Destroy(raioDireita, 1.6f);
            Destroy(raioEsquerda, 1.6f);

            bossAnim.bossAnimator.ResetTrigger("isCasting");
            }  
    }

    void AtackRandom()
    {
       

        
        int numeroDeAtaques = 2; // Atualize conforme o número de métodos de ataque
        int indiceAleatorio = Random.Range(1, numeroDeAtaques + 1);
        switch (indiceAleatorio)
        {
            case 0:
                velocidade = velNormal;
                Debug.Log("Ataque1");
                
                    break;
            case 1:
                Debug.Log("Ataque2");
                velocidade = velparado;
                distanciaEntreRaios = 2.0f;
                StartCoroutine(AtivarPoder());
                
                break;
            case 2:
                Debug.Log("Ataque2");
                velocidade = velparado;
                distanciaEntreRaios = 10.0f;
                StartCoroutine(AtivarPoder());
                break;
            case 3:
                velocidade = velNormal;
                Debug.Log("Ataque1");
 
                break;
            case 4:
                Debug.Log("Ataque2");
                velocidade = velparado;
                distanciaEntreRaios = 20.0f;
                StartCoroutine(AtivarPoder());
                distanciaEntreRaios = 10.0f;
                StartCoroutine(AtivarPoder());
                break;
        }
    }
    
}
