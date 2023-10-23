using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEye_animController : MonoBehaviour
{
    [SerializeField] Animator eyeAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyFollowCombat.enemyFolCombat.damage == true)
        {
            eyeAnim.SetTrigger("isDeath");
        }
    }
}
