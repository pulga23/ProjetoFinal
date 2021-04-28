using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    public int lives = 3;

    [SerializeField]
    private Text livesText;

    private void Update()
    {
        Debug.Log(lives);
        livesText.text = lives.ToString();
        
    }
    //palyer touches a poisonous plant
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PoisonousPlant"))
        {
            Debug.Log("esta planta é venenosa!");
            lives--; //remove a live to the player
            if (lives <= 0)
            {
                GameObject.FindGameObjectWithTag("Set").GetComponent<Geral>().GameOver(); //start Game OVer method when palyer has no lives left
            }
        }
    }
}
