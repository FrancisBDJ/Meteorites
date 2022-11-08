using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritHitsPlayer : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy(collision.gameObject);
            // Debug.Log("Die!");
            _playerHealth.takeDamage(30f);
        }
        Destroy(gameObject);
    }
}
