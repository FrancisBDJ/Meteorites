using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitsEnemy : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameManager.TakeDamage(10f);
        }
    }
}
