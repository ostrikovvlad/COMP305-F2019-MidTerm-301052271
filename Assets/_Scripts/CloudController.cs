using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

public class CloudController : MonoBehaviour
{
    [Header("Speed Values")]
    [SerializeField]
    public Speed horizontalSpeedRange;

    [SerializeField]
    public Speed verticalSpeedRange;

    public float verticalSpeed;
    public float horizontalSpeed;

    [SerializeField]
    public Boundary boundary;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    /// <summary>
    /// This method moves the ocean down the screen by verticalSpeed
    /// </summary>
    void Move()
    {
        if (SceneManager.GetActiveScene().name != "Level 2")
        {
            Vector2 newPosition = new Vector2(horizontalSpeed, verticalSpeed);
            Vector2 currentPosition = transform.position;

            currentPosition -= newPosition;
            transform.position = currentPosition;
        }
        else
        {
            Vector2 newPosition = new Vector2(verticalSpeed, horizontalSpeed);
            Vector2 currentPosition = transform.position;

            currentPosition -= newPosition;
            transform.position = currentPosition;
        }


    }

    /// <summary>
    /// This method resets the ocean to the resetPosition
    /// </summary>
    void Reset()
    {
        if (SceneManager.GetActiveScene().name != "Level 2")
        {
            horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);
            verticalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);

            float randomXPosition = Random.Range(boundary.Left, boundary.Right);
            transform.position = new Vector2(randomXPosition, Random.Range(boundary.Top, boundary.Top + 2.0f));
        }
        else
        {
            horizontalSpeed = Random.Range(horizontalSpeedRange.min, horizontalSpeedRange.max);
            verticalSpeed = Random.Range(verticalSpeedRange.min, verticalSpeedRange.max);

            float randomYPosition = Random.Range(boundary.Bottom, boundary.Top);
            transform.position = new Vector2(Random.Range(3.6f, 4.6f), randomYPosition);
        }

    }

    /// <summary>
    /// This method checks if the ocean reaches the lower boundary
    /// and then it Resets it
    /// </summary>
    void CheckBounds()
    {
        if (SceneManager.GetActiveScene().name != "Level 2")
        {
            if (transform.position.y <= boundary.Bottom)
            {
                Reset();
            }
        }
        else
        {
            if (transform.position.x <= -3.7f)
            {
                Reset();
            }
        }

    }
}
