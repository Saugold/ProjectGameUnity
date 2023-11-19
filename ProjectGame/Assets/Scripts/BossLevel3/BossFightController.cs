using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightController : MonoBehaviour
{
    public GameObject boss;
    public GameObject raio;
    public GameObject bossLife;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boss.SetActive(true);
            raio.SetActive(true);
            bossLife.SetActive(true);
        }
    }
}
