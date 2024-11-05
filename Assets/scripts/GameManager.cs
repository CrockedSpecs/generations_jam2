using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.Playables;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Main Panel")]
    [SerializeField] GameObject MainPanel;
    [SerializeField] GameObject creditPanel;
    [SerializeField] GameObject tutorialPanel;
   
    [Header("Options Panel Game")]
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject PausedPanel;
    [SerializeField] TMP_Text timer;
    [SerializeField] AudioClip levelMusic;
    public bool gameOver;

     private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

     private void Start()
    {
        Time.timeScale = 1;
        gameOver = false;

    }


    ///////Menu Principal///////////////////
    
     public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void credits()
    {
    
        MainPanel.SetActive(false);
        creditPanel.SetActive(true);
       // PanelTime.SetActive(false);
        Debug.Log("creditos");
    }

    public void tutorial(){
        MainPanel.SetActive(false);
        tutorialPanel.SetActive(true);
        Debug.Log("Tutorialpanel");
    }

    public void goBack(){
        MainPanel.SetActive(true);
        tutorialPanel.SetActive(false);
        creditPanel.SetActive(false);
        Debug.Log("return");
    }
    //////////////////////////////Pausa///////////////////////////
    
      public void pauseGame()
    {
        Time.timeScale = 0;
        PausedPanel.SetActive(true);
        //PanelTime.SetActive(false);
    }

    public void Return(){
        Time.timeScale = 1;
        PausedPanel.SetActive(false);

    }

    public void goMainMenu()
    {

        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.DeleteAll();

    }

    public void playAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level2");//SceneManager.GetSceneByBuildIndex(2).buildIndex);
        //PanelTime.SetActive(true);
        Debug.Log("Again!!");

    }


}
