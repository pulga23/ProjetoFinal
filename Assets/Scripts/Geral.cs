using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Geral : MonoBehaviour
{
    [SerializeField]
    private float timeLeft = 10f; //time the character has to get through the game

    [SerializeField]
    private Text timeText; //time the player has left to show on screen

    [SerializeField]
    private float releaseGasTime = 30f; //whem player has this time left gas is released to kill them

    private bool timeRunning=true; //variable to make the time count stop when we want or when time is zero

    private bool gasReleased = false; // variable to know if the gas has already been released

    private float minutes;
    private float seconds;

   

    
    // Update is called once per frame
    void Update()
    {
        CountAndPrintTime(); //calling method to cont and print to the scrren the time

               
    }

    //method to count and print to unity the time remaining
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
            if (timeLeft > 0) //check if there is time left
            {
                timeLeft -= Time.deltaTime; //contdown the time the player has left

            }
            else
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
    public void GameOver() //actions to run when the player dies
    {
        //stop counting time
        timeRunning = false;
        timeLeft = 0f;

        //set lives to 0
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().lives = 0;

        //stop the movement
        //Time.timeScale = 0f;

        // game over sscene
        SceneManager.LoadScene("GameOver");
        
    }
}
