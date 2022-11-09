using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    private float health = 100.0f;

    
    // Cached references
    private SpawnCoin _spawnCoin;
    
    
    
    [SerializeField] private TextMeshProUGUI _txtCoins;
    [SerializeField] private TextMeshProUGUI _txtWinMessage;
    [SerializeField] private Button _btnReiniciar;
    [SerializeField] private GameObject _player;
    [SerializeField] private Slider _healthBar;
    private bool win = false;
    private int playerPrefsLevel;
    private int coinCount = 0;
    private int coinCountL = 0;
    
    private void Start()
    {
        
        _spawnCoin = FindObjectOfType<SpawnCoin>();
        _txtWinMessage.gameObject.SetActive(false);
        _btnReiniciar.onClick.AddListener(GameOver);
        _btnReiniciar.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.Save();
        }

        else
        {
            playerPrefsLevel = PlayerPrefs.GetInt("level");
            if (playerPrefsLevel == 1) 
            {
                coinCountL = 0;
            }
            else if (playerPrefsLevel == 2)
            {
                coinCountL = 0;
                coinCount = PlayerPrefs.GetInt("coins");
                _txtCoins.text = "$ " + (coinCountL + coinCount) * 10;
            }
        }
    }

    
    
    public void ReiniciarNivel()
    {
        SceneManager.LoadScene("Level1");
    }

    private void GameOver() 
    {
        if ((playerPrefsLevel == 1) && win)
        {
            PlayerPrefs.SetInt("level",2);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Level2");
        }

        else
        {
            PlayerPrefs.SetInt("level",1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameOver");
        }
        
        
        
    }
    public void IncrementarMonedas()
    {
        if (playerPrefsLevel == 1 )
        {
            if (coinCountL < 2)
            {
                coinCountL++;
                    // Debug.Log($"You have ${coinCount*10}");
                _txtCoins.text = "$ " + (coinCountL + coinCount) * 10;
                _spawnCoin.SpawnNewCoin();
            }

            else
            {
                coinCount = coinCountL;
                PlayerPrefs.SetInt("coins", coinCount);
                PlayerPrefs.Save();
                EndLevel("Congratulations. Go to Level 2");
                win = true;
            }
                
                
        }
        else if (playerPrefsLevel == 2) 
        {
            if (coinCountL < 4)
            {
                coinCountL++;
                // Debug.Log($"You have ${coinCount*10}");
                _txtCoins.text = "$ " + (coinCountL + coinCount) * 10;
                _spawnCoin.SpawnNewCoin();
            }
            else
            {
                EndLevel("You Win!");
            }
               
        }
            
            
        
        
    }

    private void EndLevel(String message)
    {
        _txtWinMessage.gameObject.SetActive(true);
        _txtWinMessage.text = message;
        _btnReiniciar.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0.0f;
    }
    
    public void TakeDamage(float damageAmount)
    {
        health = health - damageAmount;
        _healthBar.value = health;
        
        //Debug.Log("Player health: " + health);
        if (health <= 0f)
        {
            // die
            Destroy(_player);
            //EndLevel("you die! Game Over");
            SceneManager.LoadScene("GameOver");
        }   
    }
}

