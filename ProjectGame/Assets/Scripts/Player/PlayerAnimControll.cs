using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimControll : MonoBehaviour
{
    public static PlayerAnimControll playerAnimat;
    public Animator playerAni;
    [SerializeField] Collider2D playerCol;
    [SerializeField] SpriteRenderer sprite;
    private bool isGround;

    void Start()
    {
        playerAnimat = this;
    }
    void Update()
    {

        //Andando
        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D))
        {
            playerAni.SetBool("isWalk",true);
        }
        else
            playerAni.SetBool("isWalk",false);

        //Correndo
        if ((Input.GetKey(KeyCode.A)&& Input.GetKey(KeyCode.LeftShift)) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
        {
            playerAni.SetBool("isRun", true);
        }
        else
            playerAni.SetBool("isRun", false);

        //Pulando
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!IsOnGround())
            {
               
                return;
            }
            else
            {
                if (PlayerWallJump.playerWall.IsOnWall())
                {
                    playerAni.SetBool("isWallJump", true);
                }
                else if (PlayerWallJump.playerWall.IsOnWall() == false)
                {
                    Debug.Log("saiu");
                    playerAni.SetBool("isWallJump", false);
                    playerAni.SetTrigger("isJump");
                }
                else
                {

                    playerAni.SetTrigger("isJump");

                }
                
            }
            
            playerAni.SetBool("isNotJump", true);
        }

        //Grap
        if (PlayerGrappling.playerGrap.isGrap == true)
        {
            playerAni.SetTrigger("willGrap");
            playerAni.SetBool("isGrap",true);
        }
        else
            playerAni.SetBool("isGrap", false);

        //Dash
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerAni.SetTrigger("isDash");
            playerAni.SetBool("isNotDash", true);
        }
        //Morte
        if(LifeSystem.vida.life <= 0)
        {
            playerAni.SetTrigger("isDeath");
        }

    }

    bool IsOnGround()
    {
        return playerCol.IsTouchingLayers(LayerMask.GetMask("Ground"));

    }
}
