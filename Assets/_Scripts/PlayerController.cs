﻿/* Filename: PlayerController.cs
 * Author: Vladislav Ostrikov
 * Student ID: 301052271
 * Last moddified by: Vladislav Ostrikov
 * Last modififed: Oct 19, 2019
 * This script is used to manage the player controller(scene management, audio management, score management)
 * Revision History: added extra statements in the Move, Reset and CheckBoundary methods
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

public class PlayerController : MonoBehaviour
{
    public Speed speed;
    public Boundary boundary;

    public GameController gameController;

    // private instance variables
    private AudioSource _thunderSound;
    private AudioSource _yaySound;

    // Start is called before the first frame update
    void Start()
    {
        _thunderSound = gameController.audioSources[(int)SoundClip.THUNDER];
        _yaySound = gameController.audioSources[(int)SoundClip.YAY];
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    public void Move()
    {
        if (SceneManager.GetActiveScene().name != "Level 2" && SceneManager.GetActiveScene().name != "Level 3")
        {
            Vector2 newPosition = transform.position;

            if (Input.GetAxis("Horizontal") > 0.0f)
            {
                newPosition += new Vector2(speed.max, 0.0f);
            }

            if (Input.GetAxis("Horizontal") < 0.0f)
            {
                newPosition += new Vector2(speed.min, 0.0f);
            }

            transform.position = newPosition;
        }
        else
        {
            Vector2 newPosition = transform.position;

            if (Input.GetAxis("Vertical") > 0.0f)
            {
                newPosition += new Vector2(0.0f, speed.max);
            }
            if (Input.GetAxis("Vertical") < 0.0f)
            {
                newPosition += new Vector2(0.0f, speed.min);
            }

            transform.position = newPosition;
        }

    }

    public void CheckBounds()
    {
        if (SceneManager.GetActiveScene().name != "Level 2" && SceneManager.GetActiveScene().name != "Level 3")
        {
            // check right boundary
            if (transform.position.x > boundary.Right)
            {
                transform.position = new Vector2(boundary.Right, transform.position.y);
            }

            // check left boundary
            if (transform.position.x < boundary.Left)
            {
                transform.position = new Vector2(boundary.Left, transform.position.y);
            }
        }
        else
        {
            // check top boundary
            if(transform.position.y > boundary.Top)
            {
                transform.position = new Vector2(transform.position.x, boundary.Top);
            }
            // check bottom boundary
            if (transform.position.y < boundary.Bottom)
            {
                transform.position = new Vector2(transform.position.x, boundary.Bottom);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Cloud":
                _thunderSound.Play();
                gameController.Lives -= 1;
                break;
            case "Island":
                _yaySound.Play();
                gameController.Score += 100;
                break;
        }
    }

}
