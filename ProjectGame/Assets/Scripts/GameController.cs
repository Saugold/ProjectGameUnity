using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject damScreen;
    public static GameController instance;
    public float hitDuration = 0.2f;
    private bool pisca;
    public TMP_Text maiorScore;
    public int betterScore;
    public float betterTime;
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
        instance = this;
    }
    private void Awake()
    {

        betterScore = PlayerPrefs.GetInt("recorde");
        maiorScore.text = betterScore.ToString() ;
    }
    // Update is called once per frame
    void Update()
    {
        ShowTimer();
        ShowRecord();
        UpdateScore();
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
    
    public void UpdateScore()
    {
        scoreText.text = Score.score.scoreText;
    }
    public void ShowRecord()
    {
        if(PlayerDeath.instance.playerDeath == true)
        {
            if(Score.score.scoreNum > PlayerPrefs.GetInt("recorde"))
            {
                PlayerPrefs.SetInt("recorde", Score.score.scoreNum);
            }
        }
    }
    public void ShowTimer()
    {
        if (PlayerDeath.instance.playerDeath == true)
        {
            if (Timer.time.tempoFinal < PlayerPrefs.GetFloat("TimeRecord"))
            {
                PlayerPrefs.SetFloat("TimeRecord", Timer.time.tempoFinal);
            }
        }
    }
}
