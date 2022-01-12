using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] int health = 200;
    [SerializeField] GameObject deathVFX = null;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] AudioClip deathSound = null;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.75f;
    [SerializeField] AudioClip shootSound = null;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.25f;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab = null;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.5f;
    
    Coroutine firingCoroutine;

    public int Health { get { return health; } }

    public static event Action OnPlayerDeath;

    void Start()
    {
        OnPlayerDeath += Die;
    }

    void OnDestroy()
    {
        OnPlayerDeath -= Die;
    }

    void Update()
    {
        Fire();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (!damageDealer) return;
        health -= damageDealer.Damage;
        damageDealer.Hit();
        if (health <= 0) OnPlayerDeath?.Invoke();
    }

    void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
            firingCoroutine = StartCoroutine(FireContinuosly());
        if (Input.GetButtonUp("Fire1"))
            StopCoroutine(firingCoroutine);
    }

    IEnumerator FireContinuosly()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }

    void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }
}
