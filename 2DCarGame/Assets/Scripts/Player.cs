using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;

    float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal");

        var newXpos = transform.position.x + deltaX;

        var deltaY = Input.GetAxis("Vertical");
        var newYPos = transform.position.y + deltaY;

        this.transform.position = new Vector2(newXpos, newYPos);

    }
}
