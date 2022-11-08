using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int moveSpeed = 50;
    [SerializeField] private int fuerzaSalto = 4;

    private bool isGrounded = true;
    
    // Cached reference
    private Rigidbody _playerRb;
    
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Hem colisionat amb " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
    }

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= 1.1f)
        // {
        //     _playerRb = this.gameObject.GetComponent<Rigidbody>();
        //     _playerRb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        // }
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _playerRb = this.gameObject.GetComponent<Rigidbody>();
            _playerRb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.W) == true)
        {
            // Move forward
            // new Vector3(0, 0, 1)  === Vector3.forward
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // Move backwards
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        
        if (Input.GetKey(KeyCode.A) == true)
        {
            // Move left
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Move right
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }

        float rotationAngle = Input.GetAxis("Mouse X");
        transform.Rotate(0, rotationAngle, 0);
    }
}
