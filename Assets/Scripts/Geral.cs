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

    // Update is called once per frame
    void Update()
    {
  
        timeLeft -= Time.deltaTime; //contdown the time the player has left
        timeText.text = timeLeft.ToString(); //print the time to the game screen       
        if( timeLeft <= 0f) //when time is 0 
        {
            //Game Over
            GameOver();
        }
    }

    private void GameOver() //actions to run when the player dies
    {
        timeText.text = 0.ToString();  
        Debug.Log("Game Over!)");
    }
}
