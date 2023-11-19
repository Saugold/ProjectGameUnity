using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEye_animController : MonoBehaviour
{
    private Animator eyeAnim;
    private EnemyFollowCombat enemyDead;
    // Start is called before the first frame update
    void Awake()
    {
        enemyDead = GetComponent<EnemyFollowCombat>();
        eyeAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyDead.damage == true)
        {
            eyeAnim.SetTrigger("isDeath");
        }
    }
}
