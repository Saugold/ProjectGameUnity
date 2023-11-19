using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image barraDeVida;
    public float contagemVida = 100f;
    public BoxCollider2D head;
    public Rigidbody2D playerBody;
    public BossAnim bossAnim;
    public GameObject boss;
    public BossController bossController;
    public GameObject endGame;
    public bool isDeath;
    // Start is called before the first frame update
   
    
    private void Update()
    {
        if (OnHit())
        {
            playerBody.velocity += new Vector2(0f, 30f);
            StartCoroutine(TomarDano(10f));
        }
        if(isDeath == true)
        {
            StartCoroutine(EndGame());
        }
    }
    public IEnumerator TomarDano(float dano)
    {
        bossAnim.bossAnimator.SetTrigger("isDamage");
        contagemVida -= dano;
        barraDeVida.fillAmount = contagemVida / 100f;
        bossAnim.bossAnimator.ResetTrigger("isAtaque1");
        yield return new WaitForSeconds(1f);
        if (contagemVida <= 0)
        {
            Debug.Log("Morreu");
            bossController.atacando = false;
            bossAnim.bossAnimator.SetTrigger("isDeath");
            Destroy(boss, 1f);
            isDeath = true;
        }

    }
    public bool OnHit()
    {
        if(head  != null)
        {
            return head.IsTouchingLayers(LayerMask.GetMask("Player"));
        }

        return false;
    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5f);
        endGame.SetActive(true);
    }
}
