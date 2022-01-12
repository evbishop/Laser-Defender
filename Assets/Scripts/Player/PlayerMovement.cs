using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f, padding = 1f;
    float xMin, xMax, yMin, yMax;

    void Start()
    {
        SetUpMoveBoundaries();
    }

    void Update()
    {
        Move();
    }
    
    void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    void SetUpMoveBoundaries()
    {
        Camera cam = Camera.main;
        xMin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
