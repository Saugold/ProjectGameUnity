using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer time;
    public float tempoInicial;
    public float tempo;
    public float tempoFinal;
    public float tempoDecorrido;
    public string tempoAtual;
    public TMP_Text timeText;
    public TMP_Text timeRecord;
    public BoxCollider2D timeCol;
    public bool isBegin;
    void Start()
    {
        isBegin = false;
        time = this;
        timeCol = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        ShowTime();
        if (isBegin && PlayerDeath.instance.playerDeath == false)
        {
            tempoDecorrido = Time.time - tempoInicial;
            timeCol.enabled = false;
        }
        
        tempoAtual = tempoDecorrido.ToString("F2");
    }
  
    public void marcarTempo()
    {
        tempoFinal = tempoDecorrido;
        timeRecord.text  = PlayerPrefs.GetFloat("TimeRecord").ToString("F2");
    }
    public void ShowTime()
    {
        timeText.text = tempoAtual;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            isBegin = true;
            tempoInicial = Time.time - tempoDecorrido;
        }
    }
     
}
