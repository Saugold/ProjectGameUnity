using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EnemyPatDamage : MonoBehaviour
{
	[SerializeField] Collider2D enemyCol;
	[SerializeField] GameObject enemy;
	
	public bool hit {get; set;}
	
	
	// Start is called before the first frame update
	void Start()
    {
		hit = false;
	}

	// Update is called once per frame
	void Update()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
        {

			hit = true;
			enemyCol.enabled = false;
			StartCoroutine(EnemyDead());
			
            Debug.Log("Pulou");
        }
	}
	IEnumerator EnemyDead()
	{
		
		yield return new WaitForSeconds(1.5f);
		Destroy(enemy);


	}

	
}
