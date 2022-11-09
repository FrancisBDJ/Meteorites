using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] private AudioSource _playerAudioSource;
    
    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _playerAudioSource = GameObject.FindWithTag("Player").GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Add points
            //Debug.Log("10$");
            // Play sound effect collect coin
            _playerAudioSource.Play();
            _gameManager.IncrementarMonedas();
            Destroy(gameObject);
        }
    }
}
