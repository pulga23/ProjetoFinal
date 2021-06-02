using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Geral : MonoBehaviour
{
    [SerializeField]
    private float timeLeft = 300f; //time the character has to get through the game
    [SerializeField]
    private Text timeText; //time the player has left to show on screen
    private bool timeRunning=true; //variable to make the time count stop when we want or when time is zero
    private float minutes;
    private float seconds;

    [SerializeField]
    private float releaseGasTime = 30f; //when player has this time left gas is released to kill them  
    private bool gasReleased = false; // variable to know if the gas has already been released

    [SerializeField]
    private GameObject pauseScreen; // game object to stpre the pause screen
    private bool gamePaused = false; // variable to know if the game is paused

    bool fog = false; //variable to control if the fog is on or off
    float fogDensity = 0.1f; // control fog density
    Color fogColor = new Color (0.5f, 0.5f, 0.5f, 0.5f); //variable color to keep the fog color for when we want to turn fog on
    Color poisonColor = new Color(0.4f, 0.7f, 0.5f, 1f); //variable colour to keep the color for the poison to be when released
        
    private void Start()
    {
        pauseScreen.gameObject.SetActive(false); //hides the pause screen 
        Time.timeScale = 1f; //start time
        RenderSettings.fog = false; //fog off when game starts
    }

    void Update()
    {
        CountAndPrintTime(); //calling method to cont and print to the scrren the time
        if (Input.GetKeyDown(KeyCode.P)) //pause  or unpause the game
        {
            if (gamePaused == false) //game is running, let's pause it
            {
                PauseGame(); //call the method to pause the game
            }
            else if (gamePaused == true) //game is paused let's return
            {
                ReturnGame(); //call the method to return to the game
            }
        }
        if (gamePaused == true) //if game is paused player can return to the menu or quit the game
        {
            if (Input.GetKeyDown(KeyCode.Return)) //press enter to return to menu
            {
                SceneManager.LoadScene("MainMenu"); //load menu scene
            }
            if (Input.GetKeyDown(KeyCode.Escape)) //press escape to quit game
            {
                Application.Quit();
            }
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            if (fog) EndFog();
            else if (!fog) StartFog();
        }

    }

    //method to count and print to unity the time remaining
    //adapted from https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
    private void CountAndPrintTime()
    {
        //count the time
        if(timeRunning == true) //check if time is still running
        {
            if(timeLeft < releaseGasTime && gasReleased == false) //time when gas is realeased
            {
                gasReleased = true; //only runs once
                //code to release the gas
            }
            if (timeLeft > 0f) //check if there is time left
            {
                timeLeft = timeLeft - Time.deltaTime; //contdown the time the player has left
            }
            if(timeLeft <= 0f)
            {
                timeRunning = false; //bool variable to make it only run once
                timeLeft = 0f;
                GameOver(); //call method that runs when player dies
            }
        }
        //convert time to format minutes:seconds and print
        minutes = Mathf.FloorToInt(timeLeft / 60); //multiply per 60 to get the minutes
        seconds = Mathf.FloorToInt(timeLeft % 60); //modular operation by 60 to get the seconds
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds); //print the time to the game screen in the format 00:00   
    }
    
    //method to run when the player dies
    public void GameOver() 
    { 
        timeRunning = false; //stop counting time
        timeLeft = 0f; //set time to 0
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().lives = 0; //set lives to 0
        SceneManager.LoadScene("GameOver"); //load game over scene
    }

    //method to pause the game
    private void PauseGame()
    {
        gamePaused = true; //game is now paused, so the variable is true
        pauseScreen.gameObject.SetActive(true); //shows pause screen
        Time.timeScale = 0f; //"stops" the game
    }

    //method to return to the game
    private void ReturnGame()
    {
        gamePaused = false; // game is not paused, so the variable is false
        pauseScreen.gameObject.SetActive(false); // hides pause screen
        Time.timeScale = 1f; //time starts agaisn
    }

    //method to "start" the fog - adapted from https://docs.unity3d.com/ScriptReference/RenderSettings.html
    private void StartFog()
    {
        RenderSettings.fogDensity = fogDensity; //set fog density to 0.1f
        RenderSettings.fogColor = fogColor; //change color to fog color
        RenderSettings.fog = true; //enable fog in the lighting settings 
        fog = true; //fog is on
    }

    //method to "end" the fog 
    private void EndFog()
    {
        RenderSettings.fog = false; //disable fog in the lighting settings 
        fog = false; //fog is off
    }
}
