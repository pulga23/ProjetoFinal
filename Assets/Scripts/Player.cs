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

    //private List<string> inventary = new List<string>();  //list for player inventary
    //private string auxSlingShot;
    //private string[] inventary = new string[3];

    [SerializeField]
    private int weaponPart = 0; //variable to control the number of parts of the sling shot the player has 

    //private int healthKit = 0; //variable to control extra lives the player can catch 
    private void Update()
    {
        livesText.text = lives.ToString(); //print number of lives to screen
        if(weaponPart==3) //slingshot complete
        {
            //player can use the slingshot 
        }
        
    }
    //palyer touches something
    private void OnTriggerEnter(Collider other)
    {
        //palyer touches a poisonous plant
        if (other.CompareTag("PoisonousPlant"))
        {
            lives--; //remove a live to the player
            if (lives <= 0)
            {
                GameObject.FindGameObjectWithTag("Set").GetComponent<Geral>().GameOver(); //start Game OVer method when palyer has no lives left
                
            }
        }
        //player touches a weapon part and collects it. THERE ARE ONLY 3 PARTS IN THE LABIRYNTH AND THE PLAYER HAS TO CATCH THEM ALL  
        if (other.CompareTag("WeaponPart"))
        {
            //inventary.Add("slingshot");
            // inventary[weaponPart] = "slingshot"; //Add part to player inventary
            Destroy(other.gameObject); //destroy weapon part game object
            weaponPart++;

        }
       //player collects a health kit which means an extra live
        if(other.CompareTag("HealthKit"))
        {
            lives++; //adds a live to the player
            Destroy(other.gameObject); //destroy health kit
        }
    }

   
}
