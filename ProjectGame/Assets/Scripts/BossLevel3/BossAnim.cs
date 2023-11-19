using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossAnim : MonoBehaviour
{
    public Animator bossAnimator;
    
    

    public void AnimAtack1()
    {
        bossAnimator.SetTrigger("isAtaque1");
    }
    public void AnimAtack2()
    {
        bossAnimator.SetTrigger("isCasting");
    }
    public void Walk(bool situacao)
    {
        bossAnimator.SetBool("isWalk", situacao);
    }
    
}
