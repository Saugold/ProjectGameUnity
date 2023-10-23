using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyPatDamage : MonoBehaviour
{
	[SerializeField] Collider2D enemyCol;
	[SerializeField] GameObject enemy;
	[SerializeField] Transform headPoint;
	public float heigh;


	public bool hit { get; set; }


	// Start is called before the first frame update
	void Start()
	{
		hit = false;
	}

	// Update is called once per frame
	void Update()
	{

	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			heigh = collision.contacts[0].point.y - headPoint.position.y;
			if (heigh > 0)
			{
				EnemyPatrulheiro.enemyPat.speed = 0;
				hit = true;
				enemyCol.enabled = false;
				StartCoroutine(EnemyDead());

				Debug.Log("Pulou");
			}

		}
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		heigh =  0;
	}
	IEnumerator EnemyDead()
	{
		
		yield return new WaitForSeconds(1.5f);
		Destroy(enemy);


	}

	
}
