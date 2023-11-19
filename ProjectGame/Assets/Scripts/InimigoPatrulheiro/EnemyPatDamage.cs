using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyPatDamage : MonoBehaviour
{
	[SerializeField] Collider2D enemyCol;
	[SerializeField] Collider2D enemyColhead;
	[SerializeField] GameObject enemy;
	[SerializeField] Transform headPoint;
    public EnemyPatrulheiro enemyDead;
    public Rigidbody2D enemyRig;
	public float heigh;


	public bool hit { get; set; }


	// Start is called before the first frame update
	void Awake()
	{
		enemyDead = GetComponent<EnemyPatrulheiro>();
		hit = false;
		enemyColhead = GetComponent<BoxCollider2D>();
		enemyRig = GetComponent<Rigidbody2D>();
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
			if (heigh > 0 && enemyDead.isDead ==false)
			{
				enemyDead.isDead = true;
				enemyRig.constraints = RigidbodyConstraints2D.FreezeAll;
				hit = true;
				this.enemyCol.enabled = false;
                this.enemyColhead.enabled = false;
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
        Score.score.ScoreUpdate(10);
        yield return new WaitForSeconds(0.5f);
		Destroy(enemy);


	}

	
}
