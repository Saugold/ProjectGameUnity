using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpell : MonoBehaviour
{
    public LifeSystem Life;
   
    public Rigidbody2D playerBody;
    public static BossSpell spell;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Life = player.GetComponent<LifeSystem>();
        playerBody = player.GetComponent<Rigidbody2D>();
        spell = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SpellHit();
        }
    }
    public void SpellHit()
    {
            Debug.Log("raio");
            playerBody.velocity += new Vector2(0f, 15f);
            Life.life = Life.life - 2;
            GameController.instance.TomarDano(); ;
    }
    
        
}
