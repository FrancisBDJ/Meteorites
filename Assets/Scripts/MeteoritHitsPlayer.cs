using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritHitsPlayer : MonoBehaviour
{
    private GameManager _gameManager;

    private AudioSource meteoriteAudioSource;

    [SerializeField] private AudioClip hitsPlayer;
    [SerializeField] private AudioClip hitsSomething;
    [SerializeField] private ParticleSystem hitSomeThingParticleSystem;
    [SerializeField] private ParticleSystem hitPlayerParticleSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        meteoriteAudioSource = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //meteorite hits player audio clip
            meteoriteAudioSource.PlayOneShot(hitsPlayer, 1.0f);
            hitPlayerParticleSystem.Play();
            _gameManager.TakeDamage(30f);
        }
        else
        {
            //meteorite hits something
            meteoriteAudioSource.PlayOneShot(hitsSomething, 1.0f);
            hitSomeThingParticleSystem.Play();
        }
        Destroy(gameObject, 1f);
    }
}
