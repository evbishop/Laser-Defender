using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] AudioClip shootSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.2f;
    [SerializeField] float projectileSpeed = 30f, projectileFiringPeriod = 0.1f;
    Coroutine firingCoroutine;

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
            firingCoroutine = StartCoroutine(FireContinuously());
        if (Input.GetButtonUp("Fire1"))
            StopCoroutine(firingCoroutine);
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }
}
