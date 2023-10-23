using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject damScreen;
    public static GameController instance;
    public float hitDuration = 0.2f;
    private bool pisca;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator FlashOnHit()
    {
        float elapsedTime = 0f;

        while (elapsedTime <= hitDuration)
        {
            pisca = !pisca;
            damScreen.SetActive(pisca);
            
           
            yield return new WaitForSeconds(0.1f);
            
            elapsedTime += 0.1f;
        }
        pisca = false;
        // Retorna a tela para disable.
        damScreen.SetActive(pisca);

    }
    public void TomarDano()
    {
        StartCoroutine(FlashOnHit());
    }
    
}
