using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteorit : MonoBehaviour
{
    // Cached references
    [SerializeField]
    private GameObject meteoritPrefab;

    private float timer = 0.0f;
    private float meteoritSpawnFrequency = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        
        // _rigidbody = GetComponent<Rigidbody>();
        // _rigidbody.velocity = playerTransform.position - transform.position;
        Instantiate(meteoritPrefab, transform.position, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > meteoritSpawnFrequency)
        {
            Instantiate(meteoritPrefab, transform.position, Quaternion.identity);
            timer = 0f;
        }
        
        // InvokeRepeating
        // Coroutines
    }
}
