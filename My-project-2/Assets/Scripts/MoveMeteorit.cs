using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMeteorit : MonoBehaviour
{
    // Cached reference
    private GameObject _player;
    private Rigidbody _meteoritRigidbody;

    
    private Vector3 _direction;

    [SerializeField] private float meteoritSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _meteoritRigidbody = GetComponent<Rigidbody>();
        _direction = _player.transform.position - transform.position;
        _meteoritRigidbody.velocity = _direction * meteoritSpeed;
        Debug.Log("El meteorit " + gameObject.name + " surt amb una velocitat de "
                  + _meteoritRigidbody.velocity + " " + _meteoritRigidbody.velocity.magnitude);
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(_direction * Time.deltaTime * meteoritSpeed);
    }
    
}
