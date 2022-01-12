using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] float health = 100f;
    [SerializeField] int scoreValue = 100;

    [Header("Shooting")]
    float shotCounter = 1f;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 1f;
    [SerializeField] GameObject laserPrefab = null;
    [SerializeField] float projectileSpeed = -10f;

    [Header("Effects")]
    [SerializeField] GameObject deathVFX = null;
    [SerializeField] float durationOfExsplosion = 1f;
    [SerializeField] AudioClip deathSound = null;
    [SerializeField] [Range(0,1)] float deathSoundVolume = 0.75f;
    [SerializeField] AudioClip shootSound = null;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;

    void Start()
    {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    void Update()
    {
        CountDownAndShoot();
    }

    void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }

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
        FindObjectOfType<ScoreHander>().Score += scoreValue; 
        Destroy(gameObject);
        GameObject exsplosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(exsplosion, durationOfExsplosion);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }
}
