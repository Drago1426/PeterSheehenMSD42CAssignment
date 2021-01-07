using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float health = 100f;

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.7f;

    float xMin, xMax;


    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        
        DamageDealer dmgDealer = otherObject.GetComponent<DamageDealer>();

        if (!dmgDealer)
        {
            return;
        }

        ProcessHit(dmgDealer);
    }

    private void ProcessHit(DamageDealer dmgDealer)
    {
        health -= dmgDealer.GetDamage();
        dmgDealer.Hit();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ViewPortToWorldPoint();
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
