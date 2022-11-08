using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Cached references
    private SpawnCoin _spawnCoin;
    [SerializeField] private TextMeshProUGUI _txtCoins;
    [SerializeField] private TextMeshProUGUI _txtWinMessage;
    [SerializeField] private Button _btnReiniciar;
    private void Start()
    {
        _spawnCoin = FindObjectOfType<SpawnCoin>();
        _txtWinMessage.gameObject.SetActive(false);
        _btnReiniciar.onClick.AddListener(ReiniciarNivel);
        _btnReiniciar.gameObject.SetActive(false);
    }

    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(0);
    }
    
    private int coinCount = 0;
    
    public void IncrementarMonedas()
    {
        if (coinCount < 2)
        {
            coinCount++;
            // Debug.Log($"You have ${coinCount*10}");
            _txtCoins.text = "$ " + coinCount * 10;
            _spawnCoin.SpawnNewCoin();
        }
        else
        {
            _txtWinMessage.gameObject.SetActive(true);
            _btnReiniciar.gameObject.SetActive(true);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
            //Pausar el juego
            Time.timeScale = 0;
        }
    }
}
