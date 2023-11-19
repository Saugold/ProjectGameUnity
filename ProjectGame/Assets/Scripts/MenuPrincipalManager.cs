using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private GameObject menuIniciar;
    [SerializeField] private GameObject menuOptions;
    [SerializeField] private GameObject faseOptions;
    [SerializeField] private GameObject backMenu;
    public bool iniciante;
    public DataManager dataManager;
    public static MenuPrincipalManager menuInstance;
    //--------------in Game-------------------------
    [SerializeField] private GameObject menu;
    void Start()
    {
        menuInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EscolherFase()
    {
        faseOptions.SetActive(true);
        backMenu.SetActive(true);
    }
    public void Jogar(string levelName)
    {
        SceneManager.LoadSceneAsync(levelName);
        iniciante = false;
        
    }
    public void Inicio()
    {
        SceneManager.LoadSceneAsync("Level_test 1");
        iniciante = true;
        
    }
    public void OpenOptions()
    {
        menuIniciar.SetActive(false);
        menuOptions.SetActive(true);
        backMenu.SetActive(true);

    }
    public void CloseOptions()
    {
        faseOptions.SetActive(false);
        menuOptions.SetActive(false);
        menuIniciar.SetActive(true);
        backMenu.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("saiu");
        Application.Quit();
    }
    //------------GAMMA OPTIONS---------//
    public void BackTOMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
    public void Continuar()
    {
        menu.SetActive(false);
    }
    public void Reiniciar(string fase)
    {
        SceneManager.LoadSceneAsync(fase);
    }
    public void Menu()
    {
        menu.SetActive(true);
    }


}
