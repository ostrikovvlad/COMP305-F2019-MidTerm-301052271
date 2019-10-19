/* Filename: IslandController.cs
 * Author: Vladislav Ostrikov
 * Student ID: 301052271
 * Last moddified by: Vladislav Ostrikov
 * Last modififed: Oct 19, 2019
 * This script is used to manage the island object controller(movement, reseting, checking boundaries)
 * Revision History: added extra statements to handle movement, resetment and checking boundaries for ocean object in the every scene(Start, Main,
 * Level 2, Level 3, and End). 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

public class IslandController : MonoBehaviour
{
    public float speed = 0.04f;


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
        // If the player is in the scene that is not the Level 2 or Level 3 scene then use this method for managing island moving
        // Move on the y axis from top to bottom
        if (SceneManager.GetActiveScene().name != "Level 2" && SceneManager.GetActiveScene().name != "Level 3")
        {
            Vector2 newPosition = new Vector2(0.0f, speed);
            Vector2 currentPosition = transform.position;

            currentPosition -= newPosition;
            transform.position = currentPosition;
        }
        // If the player is in the Level 2 scene then use this method for managing island moving
        // Move on the x axis from right to left
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            Vector2 newPosition = new Vector2(speed, 0.0f);
            Vector2 currentPosition = transform.position;

            currentPosition -= newPosition;
            transform.position = currentPosition;
        }
        // If the player is in the Level 3 scene then use this method for managing island moving
        // Move on the x axis from left ro right
        else if (SceneManager.GetActiveScene().name == "Level 3")
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
        // If the player is in the scene that is not the Level 2 or Level 3 scene then use this method for managing island reseting
        if (SceneManager.GetActiveScene().name != "Level 2" && SceneManager.GetActiveScene().name != "Level 3")
        {
            float randomXPosition = Random.Range(boundary.Left, boundary.Right);
            transform.position = new Vector2(randomXPosition, boundary.Top); // Resets to the position at topBoundary y and a random position at x axis
        }
        // If the player is in the Level 2 scene then use this method for managing island reseting
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            float randomYPosition = Random.Range(boundary.Top - 0.5f, boundary.Bottom + 0.5f);
            transform.position = new Vector2(boundary.Right + 0.82f, randomYPosition); // Resets to the position at rightBoundary + 0.82 at x and a random position at y axis
        }
        else if(SceneManager.GetActiveScene().name == "Level 3")
        {
            float randomYPosition = Random.Range(boundary.Top - 0.5f, boundary.Bottom + 0.5f);
            transform.position = new Vector2(boundary.Left - 0.82f, randomYPosition);
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
            if (transform.position.y <= boundary.Bottom)
            {
                Reset();
            }
        }
        else if(SceneManager.GetActiveScene().name == "Level 2")
        {
            if (transform.position.x <= boundary.Left - 0.7f)
            {
                Reset();
            }
        }
        else if(SceneManager.GetActiveScene().name == "Level 3")
        {
            if(transform.position.x >= boundary.Right + 0.7f)
            {
                Reset();
            }
        }

    }
}
