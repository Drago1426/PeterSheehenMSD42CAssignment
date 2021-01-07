using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float health = 1f;

    [SerializeField] float shotCounter;

    [SerializeField] float minTimeBetweenShots = 0.2f;

    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject objectBulletPrefab;

    [SerializeField] float objectBulletSpeed = 0.3f;

    [SerializeField] float objectBulletDamage = 1f;

    [SerializeField] bool shoot = false;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        if (!dmgDealer)
        {
            return;
        }

        ProcessHit(dmgDealer);
    }

    private void ProcessHit(DamageDealer dmgDealer)
    {
        health -= dmgDealer.GetDamage();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f && shoot == true)
        {
            ObstacleFire();

            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void ObstacleFire()
    {
        GameObject objectBullet = Instantiate(objectBulletPrefab, transform.position, Quaternion.identity) as GameObject;

        objectBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -objectBulletSpeed);
    }
}
