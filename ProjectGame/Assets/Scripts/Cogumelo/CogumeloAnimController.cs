using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class CogumeloAnimController : MonoBehaviour
{
    [SerializeField] private Animator cogAnim;
    [SerializeField] private Collider2D cogCol;
    [SerializeField] private Transform headPoint;
   
    public float heigh;

    // Update is called once per frame
    void Update()
    {
        if (EnemyPatrulheiro.enemyPat.speed > 0)
            cogAnim.SetBool("isRun", true);
        else
            cogAnim.SetBool("isRun", false);

    }
    //ataque
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            cogAnim.SetTrigger("isAttack");
            //cogAnim.SetTrigger("parado");
            //morte
            heigh = col.contacts[0].point.y - headPoint.position.y;
            if (heigh > 0)
            {
                cogAnim.SetTrigger("isDeath");
            }
        }
    }
    
    
}
