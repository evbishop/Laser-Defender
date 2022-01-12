using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] int health = 200;
    [SerializeField] GameObject deathVFX = null;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] AudioClip deathSound = null;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;

    public event Action<int> OnPlayerHealthUpdated;
    public static event Action OnPlayerDeath;

    public int Health 
    { 
        get { return health; } 
        private set 
        { 
            health = value;
            OnPlayerHealthUpdated?.Invoke(health);
        }
    }

    void Start()
    {
        OnPlayerDeath += Die;
    }

    void OnDestroy()
    {
        OnPlayerDeath -= Die;
    }

    void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (!damageDealer) return;
        Health -= damageDealer.Damage;
        damageDealer.Hit();
        if (Health <= 0) OnPlayerDeath?.Invoke();
    }
}
