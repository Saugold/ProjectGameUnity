using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private BoxCollider2D killCol;
    public LifeSystem Life;
    // Start is called before the first frame update
    void Awake()
    {
        killCol = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Life.life = 0;
        }
    }
}
