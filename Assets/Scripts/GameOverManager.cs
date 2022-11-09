using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverManager : MonoBehaviour
{
    
    
    [SerializeField]
    private Button btnReiniciar;
    [SerializeField]
    private Button btnMainMenu;
    [SerializeField]
    private Button btnExit;
    
    
    private void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    void Start()
    {
        btnMainMenu.onClick.AddListener(GoToMainMenu);
        btnExit.onClick.AddListener(QuitGame);
        btnReiniciar.onClick.AddListener(LoadLevel1);

    }

    private void QuitGame()
    {
         #if UNITY_EDITOR
        
            EditorApplication.isPlaying = false;
    
             
        #else 
            Application.Quit();
    #endif
    }
    
   

}
