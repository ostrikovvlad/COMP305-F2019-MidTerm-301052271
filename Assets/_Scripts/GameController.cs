/* Filename: GameController.cs
 * Author: Vladislav Ostrikov
 * Student ID: 301052271
 * Last moddified by: Vladislav Ostrikov
 * Last modififed: Oct 19, 2019
 * This script is used to manage the game overall(scene management, audio management, score management)
 * Revision History: changed value of Lives and Score in the start method; added extra statements in the Score and Lives properties
 *                   added livesScore to store lives; added 2 extra cases in the SceneConfiguration 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Scene Game Objects")]
    public GameObject cloud;
    public GameObject island;
    public int numberOfClouds;
    public List<GameObject> clouds;

    [Header("Audio Sources")]
    public SoundClip activeSoundClip;
    public AudioSource[] audioSources;

    [Header("Scoreboard")]
    [SerializeField]
    private int _lives;

    [SerializeField]
    private int _score;

    public Text livesLabel;
    public Text scoreLabel;
    public Text highScoreLabel;

    public GameObject highScore;
    public GameObject livesScore;

    [Header("UI Control")]
    public GameObject startLabel;
    public GameObject startButton;
    public GameObject endLabel;
    public GameObject restartButton;

    // public properties
    public int Lives
    {
        get
        {
            return _lives;
        }

        set
        {
            _lives = value;
            // If Lives is less than livesScore than assign Lives to livesScore
            if(livesScore.GetComponent<LivesScore>().lives > _lives)
            {
                livesScore.GetComponent<LivesScore>().lives = _lives;
            }
            // If lives is less than 1 then load end scene
            if (_lives < 1 && SceneManager.GetActiveScene().name != "End")
            {
                
                SceneManager.LoadScene("End");
            }
            else
            {
                livesLabel.text = "Lives: " + _lives.ToString();
            }
           
        }
    }

    public int Score
    {
        get
        {
            return _score;
        }

        set
        {
            _score = value;

            
            // If highScore is less than Score than assign Score to highScore
            if (highScore.GetComponent<HighScore>().score < _score)
            {
                highScore.GetComponent<HighScore>().score = _score;
            }
            // If Score is equals to 500 and it is not the first level or the end scene, then load second level
            if(_score == 500 && SceneManager.GetActiveScene().name != "Level 2" && SceneManager.GetActiveScene().name != "End")
            {
                SceneManager.LoadScene("Level 2");
            }
            // If Score is equals to 1000 and it is not the third level or the end scene, then load third level
            if (_score == 1000 && SceneManager.GetActiveScene().name != "Level 3" && SceneManager.GetActiveScene().name != "End")
            {
                SceneManager.LoadScene("Level 3");
            }
            scoreLabel.text = "Score: " + _score.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObjectInitialization();
        SceneConfiguration();
    }

    private void GameObjectInitialization()
    {
        highScore = GameObject.Find("HighScore");
        livesScore = GameObject.Find("LivesScore");

        startLabel = GameObject.Find("StartLabel");
        endLabel = GameObject.Find("EndLabel");
        startButton = GameObject.Find("StartButton");
        restartButton = GameObject.Find("RestartButton");
    }


    private void SceneConfiguration()
    {

        switch (SceneManager.GetActiveScene().name)
        {
            case "Start":
                scoreLabel.enabled = false;
                livesLabel.enabled = false;
                highScoreLabel.enabled = false;
                endLabel.SetActive(false);
                restartButton.SetActive(false);
                activeSoundClip = SoundClip.NONE;
                break;
            case "Main":
                highScoreLabel.enabled = false;
                startLabel.SetActive(false);
                startButton.SetActive(false);
                endLabel.SetActive(false);
                restartButton.SetActive(false);
                activeSoundClip = SoundClip.ENGINE;
                livesScore.GetComponent<LivesScore>().lives = 5; // assign the value of livesScore to 5
                highScore.GetComponent<HighScore>().score = 0; // assign the value of highScore to 0
                break;
            case "Level 2":
                highScoreLabel.enabled = false;
                startLabel.SetActive(false);
                startButton.SetActive(false);
                endLabel.SetActive(false);
                restartButton.SetActive(false);
                activeSoundClip = SoundClip.ENGINE;
                break;
            case "Level 3":
                highScoreLabel.enabled = false;
                startLabel.SetActive(false);
                startButton.SetActive(false);
                endLabel.SetActive(false);
                restartButton.SetActive(false);
                activeSoundClip = SoundClip.ENGINE;
                break;
            case "End":
                scoreLabel.enabled = false;
                livesLabel.enabled = false;
                startLabel.SetActive(false);
                startButton.SetActive(false);
                activeSoundClip = SoundClip.NONE;
                highScoreLabel.text = "High Score: " + highScore.GetComponent<HighScore>().score;
                break;
        }

        Lives = livesScore.GetComponent<LivesScore>().lives; // Assign Lives to livesScore
        Score = highScore.GetComponent<HighScore>().score; // Assign Score to highScore


        if ((activeSoundClip != SoundClip.NONE) && (activeSoundClip != SoundClip.NUM_OF_CLIPS))
        {
            AudioSource activeAudioSource = audioSources[(int)activeSoundClip];
            activeAudioSource.playOnAwake = true;
            activeAudioSource.loop = true;
            activeAudioSource.volume = 0.5f;
            activeAudioSource.Play();
        }



        // creates an empty container (list) of type GameObject
        clouds = new List<GameObject>();

        for (int cloudNum = 0; cloudNum < numberOfClouds; cloudNum++)
        {
            clouds.Add(Instantiate(cloud));
        }

        Instantiate(island);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Event Handlers
    public void OnStartButtonClick()
    {
        DontDestroyOnLoad(highScore);
        DontDestroyOnLoad(livesScore); // Keep the livesScore object in the scene
        SceneManager.LoadScene("Main");
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("Main");
    }
}
