using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float quedaDelay = 1.0f;
    public float destroyDelay = 2f;
    private bool falling = false;
    public GameObject platPrefab;
    public Rigidbody2D platRig;
    public Vector3 platPosition;
    private void Start()
    {
        platRig = GetComponent<Rigidbody2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (falling)
            return;
        if(collision.transform.tag == "Player")
        {
            StartCoroutine(GerarNovaPlat());
            StartCoroutine(StartFall());
        }
    }
    private IEnumerator StartFall()
    {
        platPosition = this.transform.position;
        falling = true;
        yield return new WaitForSeconds(quedaDelay);
        platRig.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
    

    private IEnumerator GerarNovaPlat()
    {
        Debug.Log("Gerou"); 
        GameObject newPlatform = Instantiate(platPrefab, transform.position, Quaternion.identity);
        newPlatform.SetActive(false);
        yield return new WaitForSeconds(5f);
        newPlatform.SetActive(true);

    }
}
