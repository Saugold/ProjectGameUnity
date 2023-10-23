using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerDeath : MonoBehaviour
{
    public GameObject gameOver;
    public Collider2D playerCol;
    public Rigidbody2D playerRig;
    public static PlayerDeath instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void ShowGameOver()
	{   
        playerRig.constraints = playerRig.constraints = RigidbodyConstraints2D.FreezePosition;
		playerCol.enabled = false;
        
        gameOver.SetActive(true);
        
	}
    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
}
