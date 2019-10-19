/* Filename: OceanController.cs
 * Author: Vladislav Ostrikov
 * Student ID: 301052271
 * Last moddified by: Vladislav Ostrikov
 * Last modififed: Oct 19, 2019
 * This script is used to manage the ocean object(movement, resetment, checking boundaries)
 * Revision History: added extra statements to handle movement, resetment and checking boundaries for ocean object in the every scene(Start, Main,
 * Level 2, Level 3, and End). 
 */
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
        // If the player is in the scene that is not the Level 2 or Level 3 scene then use this method for managing ocean moving
        // Move on the y axis from top to bottom
        if (SceneManager.GetActiveScene().name != "Level 2" && SceneManager.GetActiveScene().name != "Level 3")
        {
            Vector2 newPosition = new Vector2(0.0f, speed); 
            Vector2 currentPosition = transform.position;

            currentPosition -= newPosition;
            transform.position = currentPosition;
        }
        // If the player is in the Level 2 scene then use this method for managing ocean moving
        // Move on the x axis from right to left
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            Vector2 newPosition = new Vector2(speed, 0.0f); 
            Vector2 currentPosition = transform.position;

            currentPosition -= newPosition;
            transform.position = currentPosition;
        }
        // If the player is in the Level 3 scene then use this method for managing ocean moving
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
        // If the player is in the scene that is not the Level 2 or Level 3 scene then use this method for managing ocean resetment
        if (SceneManager.GetActiveScene().name != "Level 2" && SceneManager.GetActiveScene().name != "Level 3")
        {
            transform.position = new Vector2(0.0f, resetPosition); // Resets ocean object position to top position at resetPosititon 
        }
        // If the player is in the Level 2 scene then use this method for managing ocean resetment
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            transform.position = new Vector2(10.4f, 0.0f); // Resets ocean object position to right at 10.4
        }
        // If the player is in the Level 3 scene then use this method for managing ocean resetment
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            transform.position = new Vector2(-10.4f, 0.0f); // Resets ocean object position to left at 10.4
        }

    }

    /// <summary>
    /// This method checks if the ocean reaches the lower boundary
    /// and then it Resets it
    /// </summary>
    void CheckBounds()
    {
        // If the player is in the scene that is not the Level 2 or Level 3 scene then use this for boundary management
        if (SceneManager.GetActiveScene().name != "Level 2" && SceneManager.GetActiveScene().name != "Level 3")
        {
            // Call Reset method when the ocean object reaces resetPoint at y axis
            if (transform.position.y <= resetPoint)
            {
                Reset();
            }
        }
        // If the player is in the Level 2 scene then use this for boundary management
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            // Call Reset method when the ocean object reaches -14.4 at x axis
            if(transform.position.x <= -14.4)
            {
                Reset(); 
            }
        }
        // If the player is in the Level 3 scene then use this for boundary management
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            // Call Reset metjpd when the object reaches 14.4 at x axis
            if(transform.position.x >= 14.4)
            {
                Reset();
            }
        }

    }
}
