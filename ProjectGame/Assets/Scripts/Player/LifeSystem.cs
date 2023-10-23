using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
	public int life;
    public int lifeMax;
    public Image[] coracao;
    public Sprite cheio;
    public Sprite vazio;
    public GameController gameController;
    public static LifeSystem vida;
    [SerializeField] Animator[] lifeAni;
    // Start is called before the first frame update
    void Start()
    {
        vida = this;
    }

    // Update is called once per frame
    void Update()
    {
        LifeLogic();
        Death();
	}

    void LifeLogic()
    {
        if(life > lifeMax)
        {
            life = lifeMax;
        }

        for (int i = 0; i < coracao.Length; i++)
        {
            
            if(i < life)
            {
                
                coracao[i].sprite = cheio;
                lifeAni[i].SetBool("isDead", false);

            }
            else
            {
                lifeAni[i].SetBool("isDead", true);
                coracao[i].sprite = vazio;
                
            }

            if(i < lifeMax)
            {
                coracao[i].enabled = true;
            }
            else
            {
				coracao[i].enabled = false;
			}
        }
    }

    void Death()
    {
        if(life <=0)
        {
            
            GetComponent<Player>().enabled = false;
			PlayerDeath.instance.ShowGameOver();
            


        }
    }

}
