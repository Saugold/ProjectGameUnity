using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Rigidbody2D bossRig;
    private BoxCollider2D bossBoxCol;
    private CapsuleCollider2D bossCapCol;
    void Awake()
    {
        bossRig = GetComponent<Rigidbody2D>();
        bossBoxCol = GetComponent<BoxCollider2D>();
        bossCapCol = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        
    }
}
