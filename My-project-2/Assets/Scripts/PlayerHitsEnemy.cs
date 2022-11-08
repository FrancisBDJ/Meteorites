using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitsEnemy : MonoBehaviour
{
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerHealth.takeDamage(10f);
        }
    }
}
