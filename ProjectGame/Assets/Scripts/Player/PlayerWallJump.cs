using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJump : MonoBehaviour
{
    [SerializeField] Animator playerAnim;
    [SerializeField] Collider2D playerCollider;
    // Start is called before the first frame update
    public static PlayerWallJump playerWall;
    private void Start()
    {
        playerWall = this;
    }
    public bool IsOnWall()
    {
        return playerCollider.IsTouchingLayers(LayerMask.GetMask("Wall"));

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            playerAnim.SetBool("isWallJump", false);
        }
    }
}
