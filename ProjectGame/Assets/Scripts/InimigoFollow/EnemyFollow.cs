using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField]
    private Transform alvo;

    public static EnemyFollow enemyFollow;
    
    [SerializeField]
    public float speed;

    [SerializeField]
    private Rigidbody2D enemyRig;

    [SerializeField]
    private float raioVisao;

    [SerializeField]
    private LayerMask layerAreaVisao;
    [SerializeField]
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        enemyFollow = this;
    }

    // Update is called once per frame
    void Update()
    {
        ProcurarJogador();
        if (this.alvo != null)
        {
            FollowPlayer();
        }
        else
            StopFollow();
        //vira o sprite
        if(this.enemyRig.velocity.x > 0)
        {
            this.sprite.flipX = false;
        }
        else if(this.enemyRig.velocity.x < 0)
        {
            this.sprite.flipX = true;
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, this.raioVisao);
    }
    private void ProcurarJogador()
    {
        Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.raioVisao, this.layerAreaVisao);
        if (colisor != null)
        {
            this.alvo = colisor.transform;
        }
        else
            this.alvo = null;
    }

    private void FollowPlayer()
    {   
        Vector2 posicaoAlvo = this.alvo.position;
        Vector2 posicaoAtual = this.transform.position;
        Vector2 direcao = posicaoAlvo - posicaoAtual;
        direcao = direcao.normalized;
        
        this.enemyRig.velocity = (this.speed * direcao);
        
    }
    private void StopFollow()
    {
        this.enemyRig.velocity = Vector2.zero;
    }
    

}
