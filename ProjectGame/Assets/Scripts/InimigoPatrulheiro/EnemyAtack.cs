using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
    public EnemyPatDamage enemyda;
    public Rigidbody2D enemyRig;
	public LifeSystem Life;
	// Start is called before the first frame update
	void Start()
    {
        Life = Player.playerRef.GetComponent<LifeSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			if (enemyda.heigh < 0)
			{
				Life.life--;
                GameController.instance.TomarDano();
                Debug.Log("Voutemamar");
                EnemyPatrulheiro.enemyPat.speed = 0;
                StartCoroutine(PararMovimento());
            }
			
			
		}
		

	}
	private IEnumerator PararMovimento()
	{

		// Espere por um certo tempo.
		yield return new WaitForSeconds(1.5f);
		EnemyPatrulheiro.enemyPat.speed = 10;


	}
}

