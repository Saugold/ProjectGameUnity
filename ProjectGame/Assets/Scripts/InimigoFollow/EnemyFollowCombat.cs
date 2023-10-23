using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowCombat : MonoBehaviour
{
    public Rigidbody2D enemyRig;
    public LifeSystem Life;
    public static EnemyFollowCombat enemyFolCombat;
    [SerializeField] private BoxCollider2D enemyHead;
    [SerializeField] GameObject enemy;
    [SerializeField] Rigidbody2D playerBody;

    public bool damage = false;
    
    // Start is called before the first frame update
    void Start()
    {
        enemyFolCombat = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !damage)
        {
            Life.life--;
            GameController.instance.TomarDano();
            Debug.Log("Voutemamar");
            EnemyFollow.enemyFollow.speed = 0;
            StartCoroutine(StopFollow());

        }


    }
    private IEnumerator StopFollow()
    {

        // Espere por um certo tempo.
        yield return new WaitForSeconds(0.5f);
        EnemyFollow.enemyFollow.speed = 7;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            damage = true;
            EnemyFollow.enemyFollow.speed = 0;
            playerBody.velocity += new Vector2(0f, 10f);
            StartCoroutine(EnemyDead());
        }
    }
    IEnumerator EnemyDead()
    {

        yield return new WaitForSeconds(1f);
        Destroy(this.enemy);


    }
}
