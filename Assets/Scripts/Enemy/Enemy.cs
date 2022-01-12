using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float health = 100f;
    [SerializeField] int scoreValue = 100;

    [Header("Effects")]
    [SerializeField] GameObject deathVFX = null;
    [SerializeField] float durationOfExsplosion = 1f;
    [SerializeField] AudioClip deathSound = null;
    [SerializeField] [Range(0,1)] float deathSoundVolume = 0.75f;

    public static event Action<int> OnScoreIncreased;

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (!damageDealer) return;
        health -= damageDealer.Damage;
        damageDealer.Hit();
        if (health <= 0) Die();
    }

    void Die()
    {
        OnScoreIncreased?.Invoke(scoreValue); 
        Destroy(gameObject);
        GameObject exsplosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(exsplosion, durationOfExsplosion);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }
}
