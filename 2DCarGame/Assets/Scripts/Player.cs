using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int gamePoints;

    [SerializeField] int health = 50;

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.7f;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;

    [SerializeField] AudioClip playerDeathSound;
    [SerializeField] [Range(0, 1)] float playerDeathSoundVolume = 0.75f;

    [SerializeField] AudioClip playerHitSound;
    [SerializeField] [Range(0, 1)] float playerHitSoundVolume = 0.75f;

    float xMin, xMax;

    GameSession gameSession;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        
        DamageDealer dmgDealer = otherObject.GetComponent<DamageDealer>();
        Obstacle obstacle = otherObject.GetComponent<Obstacle>();

        if (!dmgDealer)
        {
            return;
        }

        ProcessHit(dmgDealer, obstacle);
    }

    private void ProcessHit(DamageDealer dmgDealer, Obstacle obstacle)
    {
        health -= dmgDealer.GetDamage();
        AudioSource.PlayClipAtPoint(playerHitSound, Camera.main.transform.position, playerHitSoundVolume);
        dmgDealer.Hit();
        obstacle.Die();
        print(health);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);

        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(explosion, explosionDuration);

        AudioSource.PlayClipAtPoint(playerDeathSound, Camera.main.transform.position, playerDeathSoundVolume);
        
        FindObjectOfType<Level>().LoadGameOver();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ViewPortToWorldPoint();
    }

    public int GetHealth()
    {
        return health;
    }

    private void ViewPortToWorldPoint()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        this.transform.position = new Vector2(newXpos, transform.position.y);

    }
}
