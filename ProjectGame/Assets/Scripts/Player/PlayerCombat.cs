using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRig;
    [SerializeField] private Collider2D playerCol;
    [SerializeField] public SpriteRenderer playerSprite;
    public bool pulou = false;
    public int playerLife;
    public LifeSystem Life;
    public Player player;
    


    // Start is called before the first frame update
    void Start()
    {
        playerLife = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Pulo();
    }

	private void OnCollisionEnter2D(Collision2D col)
	{
        if (col.gameObject.tag =="Damage"  )
        {
            Debug.Log("Encostou no safado");
            
            TomarDano();
            
            StartCoroutine(PlayerDamage(col));
			 
        }
	}

    
    public IEnumerator PlayerDamage(Collision2D collision)
    {
        player.kbCount = player.kbTime;
		if (collision.transform.position.x <= transform.position.x)
		{
			player.isKnockRight = false;
		}
		if (collision.transform.position.x >= transform.position.x)
		{
			player.isKnockRight = true;
		}
		
		yield return new WaitForSeconds(1.5f);

	}
    
    


	private void Pulo()
    {
        if(pulou == true)
        {
            playerRig.velocity += new Vector2(0f, 5f);
            Debug.Log("acertou");
		}
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("EnemyHead"))
        {
            
            pulou = true;
        }
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("EnemyHead"))
		{
			pulou = false;
		}
	}
    public void TomarDano()
    {
       
    }
    
}
