using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Geral : MonoBehaviour
{
    [SerializeField]
    private float timeLeft = 10f; //time the character has to get through the game

    [SerializeField]
    private Text timeText; //time the player has left to show on screen

    private bool timeRunning=true;

    private float minutes;
    private float seconds;

    // Update is called once per frame
    void Update()
    {
        if(timeLeft>0 && timeRunning==true) //cheack if there is time left
        {
            timeLeft -= Time.deltaTime; //contdown the time the player has left
           
        }
        //convert time to format minutes:seconds
        minutes = Mathf.FloorToInt(timeLeft / 60); //multiply per 60 to get the minutes
        seconds = Mathf.FloorToInt(timeLeft % 60); //modular operation to get the seconds
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds); //print the time to the game screen       
        
        if( timeLeft <= 0f && timeRunning == true) //when time is 0 
        {
            //Game Over
            timeRunning = false; //bool variable to make it only run once
            timeLeft = 0f;
            GameOver();
        }
    }

    private void GameOver() //actions to run when the player dies
    {
        
        Debug.Log("Game Over!)");
    }
}
