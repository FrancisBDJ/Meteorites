using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float health = 100.0f;

    public void takeDamage(float damageAmount)
    {
        health = health - damageAmount;
        Debug.Log("Player health: " + health);
        if (health <= 0f)
        {
            // die
            Destroy(gameObject);
            Debug.Log("You die!");
        }   
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
