using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyPatrulheiro : MonoBehaviour
{
    public float speed;
    public float distancia;
	public bool isDead = false;
    public bool isRight = true;
	public Transform groundCheck;
	public Transform wallCheck;
	public GameObject head;
	public static EnemyPatrulheiro enemyPat;
	[SerializeField] private Rigidbody2D enemyRig;
	[SerializeField] private Collider2D enemyCol;
	[SerializeField] private EnemyPatDamage enemyHit;
	// Start is called before the first frame update
	void Start()
    {
		enemyPat = this;
		enemyRig = this.GetComponent<Rigidbody2D>();
		enemyCol = this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (this.isDead == false)
		{
			Moviment();
		}
		if (this.isDead == true) {
			this.speed = 0;
		}
		
    }
    public void Moviment()
    {
		transform.Translate(Vector2.right * speed * Time.deltaTime);

		RaycastHit2D ground = Physics2D.Raycast(groundCheck.position, Vector2.down, distancia);
		//checando se o gound esta em contato com o chão
		if (ground.collider == false)
		{
			if (isRight == true)
			{
				transform.eulerAngles = new Vector3(0, 180, 0);
				isRight = false;
			}
			else
			{
				transform.eulerAngles = new Vector3(0, 0, 0);
				isRight = true;
			}
		}
		//checando se o inimigo bateu em uma parede ou Player
	}
	private void OnCollisionEnter2D(Collision2D collider)
	{
		if(collider.gameObject.CompareTag("Ground"))
		{
            if (isRight == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isRight = true;
            }
        }
		else if (collider.gameObject.CompareTag("Damage"))
		{
            if (isRight == true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                isRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                isRight = true;
            }
        }
		
	}
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Player"))
		{
			speed = 10;
		}
	}
	
}
