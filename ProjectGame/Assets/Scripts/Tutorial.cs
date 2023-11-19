using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Sprite[] framesPulo;
    public Sprite[] framesDash;
    public Sprite[] framesMove;
    public Sprite[] framesGrap;
    public Sprite[] framesEnemy;
    public Sprite[] framesDialog;
    public Sprite[] keyJump;
    public Sprite[] keyMove;
    public Sprite[] keyDash;
    public Sprite[] keyDialog;
    public Sprite[] keyGraple;
    public float framesPerSecond = 10f;
    public GameObject tutorial;
    public GameObject player;
    public GameObject playerImage;
    public Image image;
    public Image key;
    private int frameIndex = 0;
    private int frameIndexKey = 0;
    public BoxCollider2D move;
    public BoxCollider2D pular;
    public BoxCollider2D dash;
    public BoxCollider2D grap;
    public BoxCollider2D combat;
    public BoxCollider2D dialog;
    public TMP_Text text;
    public TMP_Text textAuxiliar;
    public int tutorialCont = 0;
    public int[] toDo;//se = 0->ja fez se = 1-> n fez
    public static Tutorial tutoInstance;

    private void Start()
    {
        tutoInstance = this;
    }
    //Player Sprite
    void Pulando()
    {
        image.sprite = framesPulo[frameIndex];
        frameIndex = (frameIndex + 1) % framesPulo.Length;
    }
    void Dash()
    {
        image.sprite = framesDash[frameIndex];
        frameIndex = (frameIndex + 1) % framesDash.Length;
    }
    void Move()
    {
        image.sprite = framesMove[frameIndex];
        frameIndex = (frameIndex + 1) % framesMove.Length;
    }
    void Grap()
    {
        image.sprite = framesGrap[frameIndex];
        frameIndex = (frameIndex + 1) % framesGrap.Length;
    }
    void Combat()
    {
        image.sprite = framesEnemy[frameIndex];
        frameIndex = (frameIndex + 1) % framesEnemy.Length;
    }
    void Dialog()
    {
        image.sprite = framesDialog[frameIndex];
        frameIndex = (frameIndex+1) % framesDialog.Length;
    }
    //keys Sprites
    void Space()
    {
        key.SetNativeSize();
        key.sprite = keyJump[frameIndexKey];
        frameIndexKey = (frameIndexKey + 1) % keyJump.Length;
    }
    void Movekey()
    {
        key.SetNativeSize();
        key.sprite = keyMove[frameIndexKey];
        frameIndexKey = (frameIndexKey + 1) % keyMove.Length;
    }
    void DashKey()
    {
        key.SetNativeSize();
        key.sprite = keyDash[frameIndexKey];
        frameIndexKey = (frameIndexKey + 1) % keyDash.Length;
    }
    void DialogKey()
    {
        key.SetNativeSize();
        key.sprite = keyDialog[frameIndexKey];
        frameIndexKey = (frameIndexKey + 1) % keyDialog.Length;
    }
    void GrapleKey()
    {
        key.SetNativeSize();
        key.sprite = keyGraple[frameIndexKey];
        frameIndexKey = (frameIndexKey + 1) % keyGraple.Length;
    }
    private void Update()
    {
        //Checando se o tutorial já foi feito
        move.enabled = DataManager.dataInstance.tutoToDo1;
        pular.enabled = DataManager.dataInstance.tutoToDo2;
        dash.enabled = DataManager.dataInstance.tutoToDo3;
        combat.enabled = DataManager.dataInstance.tutoToDo4;
        dialog.enabled = DataManager.dataInstance.tutoToDo5;
        grap.enabled = DataManager.dataInstance.tutoToDo6;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            
            tutorialCont++;
            if(tutorialCont == 1 && DataManager.dataInstance.tutoToDo1 == true)
            {
               
                frameIndex = 0;
                frameIndexKey = 0;
                InvokeRepeating("Move", 0, 1 / framesPerSecond);
                InvokeRepeating("Movekey", 0, 1 / framesPerSecond);
                text.text = "Pressione A e D para se mover";
                textAuxiliar.text = "SEGURE SHIFT PARA CORRER";
                tutorial.SetActive(true);
                move.isTrigger = false;
                
            }
            else if (tutorialCont == 2 && DataManager.dataInstance.tutoToDo2 == true)
            {
                pular.enabled = false;
                frameIndex = 0;
                frameIndexKey = 0;
                tutorial.SetActive(true);
                InvokeRepeating("Pulando", 0, 1 / framesPerSecond);
                InvokeRepeating("Space", 0, 1 / framesPerSecond);
                text.text = "Pressione ESPAÇO para pular";
                textAuxiliar.text = "Pule repetidamente para escalar paredes mas CUIDADO para não passar dos limites";
               pular.isTrigger = false;
                

            }
            else if(tutorialCont == 3 && DataManager.dataInstance.tutoToDo3 == true)
            {
                pular.enabled = false;
                InvokeRepeating("Dash", 0, 1 / framesPerSecond);
                InvokeRepeating("DashKey", 0, 1 / framesPerSecond);
                frameIndex = 0;
                frameIndexKey = 0;
                tutorial.SetActive(true);
                textAuxiliar.text = "Use o dash e pule logo em seguida para ganhar um impulso";
                text.text = "Aperte E para usar o Dash";
                dash.isTrigger = false;
                
            }
            else if (tutorialCont == 4 && DataManager.dataInstance.tutoToDo4 == true)
            {
                dash.enabled = false;
                InvokeRepeating("Combat", 0, 1 / framesPerSecond);
                frameIndex = 0;
                frameIndexKey = 0;
                tutorial.SetActive(true);
                textAuxiliar.text = "99% dos Inimigos podem ser derrotados com um pulo na cabeça, nunca jogou Mario??";
                text.text = "Pule na cabeça de um inimigo";
                image.transform.localScale = new Vector3(367.997162f, 348.30069f, 348.30069f);
                combat.isTrigger = false;
                
            }
            else if (tutorialCont == 5 && DataManager.dataInstance.tutoToDo5 == true)
            {
                InvokeRepeating("Dialog", 0, 1 / framesPerSecond);
                InvokeRepeating("DialogKey", 0, 1 / framesPerSecond);
                frameIndex = 0;
                frameIndexKey = 0;
                tutorial.SetActive(true);
                textAuxiliar.text = "Você pode conversar com alguns NPCs que possuem um ícone de balão em cima de suas cabeças";
                text.text = "Aperte W para interagir e S para pular para a próxima fala";
                dialog.isTrigger = false;

            }
            else if (tutorialCont == 6 && DataManager.dataInstance.tutoToDo6 == true)
            {
                InvokeRepeating("Grap", 0, 1 / framesPerSecond);
                InvokeRepeating("GrapleKey", 0, 1 / framesPerSecond);

                frameIndex = 0;
                frameIndexKey = 0;
                tutorial.SetActive(true);
                textAuxiliar.text = "Use A e D para balançar";
                text.text = "Quando o ponto brilhar aperte Q para se pendurar";

                grap.isTrigger = false;

            }
        }
    }
    public void NextButton()
    {
       if(tutorialCont == 1)
       {
            move.enabled = false;
            CancelInvoke("Move");
            CancelInvoke("Movekey");
            DataManager.dataInstance.tutoToDo1 = false;
            
        }
       else if(tutorialCont == 2)
        {
            pular.enabled = false;
            CancelInvoke("Pulando");
            CancelInvoke("Space");
            DataManager.dataInstance.tutoToDo2 = false;

        }
        else if (tutorialCont == 3)
        {
            dash.enabled = false;
            CancelInvoke("Dash");
            CancelInvoke("DashKey");
            DataManager.dataInstance.tutoToDo3 = false;
        }
        else if (tutorialCont == 4)
        {
            combat.enabled = false;
            CancelInvoke("Combat");
            image.transform.localScale = new Vector3(118.729263f, 112.374466f, 112.374466f);
            DataManager.dataInstance.tutoToDo4 = false;
        }
       else if (tutorialCont == 5)
        {
            dialog.enabled = false;
            CancelInvoke("Dialog");
            CancelInvoke("DialogKey");
            DataManager.dataInstance.tutoToDo5 = false;
        }
       else if( tutorialCont == 6)
        {
            grap.enabled = false;
            CancelInvoke("Grap");
            CancelInvoke("GrapleKey");
            DataManager.dataInstance.tutoToDo6 = false;
        }
        tutorial.SetActive(false);
        //col1.enabled = false;  
        player.SetActive(true);
    }
   
}
