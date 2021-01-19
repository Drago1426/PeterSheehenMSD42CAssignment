using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShredder : MonoBehaviour
{
    [SerializeField] int gamePoints = 5;
    [SerializeField] bool scoreOn = false;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        Destroy(otherObject.gameObject);

        FindObjectOfType<GameSession>().AddToScore(gamePoints);

    }
}
