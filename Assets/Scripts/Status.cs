using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField] protected int health = 200;
    [SerializeField] protected GameObject deathVFX;
    [SerializeField] protected AudioClip deathSound;
    [SerializeField] [Range(0, 1)] protected float deathSoundVolume = 0.75f;
    [SerializeField] protected float durationOfExplosion = 1f;

    public virtual int Health
    {
        get { return health; }
        protected set { health = value; }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
        GameObject exsplosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(exsplosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (!damageDealer) return;
        Health -= damageDealer.Damage;
        damageDealer.Hit();
    }
}
