using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAtack : MonoBehaviour
{
	public Rigidbody2D enemyRig;
	public LifeSystem Life;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Life.life--;
			Debug.Log("Voutemamar");
			EnemyPatrulheiro.enemyPat.speed = 0;
			StartCoroutine(PararMovimento());
			
		}
		

	}
	private IEnumerator PararMovimento()
	{

		// Espere por um certo tempo.
		yield return new WaitForSeconds(1.5f);
		EnemyPatrulheiro.enemyPat.speed = 10;


	}
}

