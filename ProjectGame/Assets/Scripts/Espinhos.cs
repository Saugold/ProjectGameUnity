using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinhos : MonoBehaviour
{
    private BoxCollider2D espinhoCol;
    public LifeSystem Life;
    // Start is called before the first frame update
    void Awake()
    {
        espinhoCol = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Life.life = 0;

        }


    }
}
