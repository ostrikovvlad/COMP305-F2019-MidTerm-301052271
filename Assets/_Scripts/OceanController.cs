using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OceanController : MonoBehaviour
{
    public float speed = 0.1f;
    public float resetPosition = 4.8f;
    public float resetPoint = -4.8f;

    // Start is called before the first frame update
    void Start()
    {
        //Reset();
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
        if (SceneManager.GetActiveScene().name != "Level 2" && SceneManager.GetActiveScene().name != "Level 3")
        {
            Vector2 newPosition = new Vector2(0.0f, speed);
            Vector2 currentPosition = transform.position;

            currentPosition -= newPosition;
            transform.position = currentPosition;
        }
        else if(SceneManager.GetActiveScene().name == "Level 2")
        {
            Vector2 newPosition = new Vector2(speed, 0.0f);
            Vector2 currentPosition = transform.position;

            currentPosition -= newPosition;
            transform.position = currentPosition;
        }
        else if(SceneManager.GetActiveScene().name == "Level 3")
        {
            Vector2 newPosition = new Vector2(speed, 0.0f);
            Vector2 currentPosition = transform.position;

            currentPosition += newPosition;
            transform.position = currentPosition;
        }
    }

    /// <summary>
    /// This method resets the ocean to the resetPosition
    /// </summary>
    void Reset()
    {
        if (SceneManager.GetActiveScene().name != "Level 2" && SceneManager.GetActiveScene().name != "Level 3")
        {
            transform.position = new Vector2(0.0f, resetPosition);
        }
        else if(SceneManager.GetActiveScene().name == "Level 2")
        {
            transform.position = new Vector2(10.4f, 0.0f);
        }
        else if(SceneManager.GetActiveScene().name == "Level 3")
        {
            transform.position = new Vector2(-10.4f, 0.0f);
        }

    }

    /// <summary>
    /// This method checks if the ocean reaches the lower boundary
    /// and then it Resets it
    /// </summary>
    void CheckBounds()
    {
        if (SceneManager.GetActiveScene().name != "Level 2" && SceneManager.GetActiveScene().name != "Level 3")
        {
            if (transform.position.y <= resetPoint)
            {
                Reset();
            }
        }
        else if(SceneManager.GetActiveScene().name == "Level 2")
        {
            if(transform.position.x <= -14.4)
            {
                Reset();
            }
        }
        else if(SceneManager.GetActiveScene().name == "Level 3")
        {
            if(transform.position.x >= 14.4)
            {
                Reset();
            }
        }

    }
}
