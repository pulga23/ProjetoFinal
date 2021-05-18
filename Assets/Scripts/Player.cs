using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    public int lives = 3; //how many lives the player has
    [SerializeField]
    private Text livesText; //print number of lives on screen

    [SerializeField]
    private GameObject pickUpPrompt; //prompt the player to press key to pick up object
    [SerializeField]
    GameObject aimPlayer; //player aim that shows on screen
    [SerializeField]
    private int weaponPart = 0; //variable to control the number of parts of the sling shot the player has 
    [SerializeField]
    GameObject playerAmmo; //what the player fires
    [SerializeField]
    private float fireRate = 0.5f;
    private float timeBetweenShots;

    private bool playerHAsWeapon = false; //check if the player has all the parts and can use the weapon       
    private bool canFire = true; //player can fire if it's been more than fireRate seconds since last shot
    
    Transform slingshot; //where the shot comes from
    Vector3 auxFire;


    private void Start()
    {
        pickUpPrompt.gameObject.SetActive(false); //hide pick up prompt
        aimPlayer.gameObject.SetActive(false); //hide aim  

        timeBetweenShots = fireRate; 
        
    }
    
    private void Update()
    {
        livesText.text = lives.ToString(); //print number of lives to screen
       //slingshot complete and ready to use 
        if(playerHAsWeapon == true) 
        {
            //while right button is down
            if(Input.GetMouseButton(1)) 
            {
                aimPlayer.gameObject.SetActive(true); //show player aim
                //when left button is pressed fire
                if(Input.GetMouseButtonDown(0) && canFire==true) //check if left button is pressed and if it has pass enough time since last shot 
                {
                    canFire = false;
                    slingshot = transform;
                    auxFire = slingshot.position;
                    auxFire.y++;
                    slingshot.position = auxFire; //increse by one the height of the shot

                    Instantiate(playerAmmo, slingshot.position, slingshot.rotation); //instatiate player shots
                }
            }
            //when right button released hide aim
            if(Input.GetMouseButtonUp(1))
            {
                aimPlayer.gameObject.SetActive(false);//hide aim when right button is released
            }

        } 
        //conts the time between shots
        if (!canFire)
        {
            timeBetweenShots -= Time.deltaTime; //countdown
            if(timeBetweenShots <=0) //when it hits zero
            {
                canFire = true; //set to true and it can fire again
                timeBetweenShots = fireRate; //restart variable
            }
        }
    }
    
    //runs when the player touches something
    private void OnTriggerEnter(Collider other)
    {
        //playerr touches a poisonous plant
        if (other.CompareTag("PoisonousPlant"))
        {
            lives--; //remove a live to the player
            if (lives <= 0)
            {
                GameObject.FindGameObjectWithTag("Set").GetComponent<Geral>().GameOver(); //start Game Over method when palyer has no lives left
            }
        }
        //player collects a health kit which means an extra live
        if(other.CompareTag("HealthKit"))
        {
            lives++; //adds a live to the player
            Destroy(other.gameObject); //destroy health kit
        }
    }
   
    //player collects items
    private void OnTriggerStay(Collider other)
    {
        //player is touching a weapon part and collects it. THERE ARE ONLY 3 PARTS IN THE LABIRYNTH AND THE PLAYER HAS TO CATCH THEM ALL  
        if (other.CompareTag("WeaponPart"))
        {
            pickUpPrompt.gameObject.SetActive(true); //print pick up prompt
            //when C is pressed
            if (Input.GetKeyDown(KeyCode.C))
            {
                Destroy(other.gameObject); //destroy weapon part game object
                weaponPart++; //add weapon part
                pickUpPrompt.gameObject.SetActive(false); //hide pick up prompt
            }
        }
        //player has all the parts and can use the weapon
        if(weaponPart==3) 
        {
            playerHAsWeapon = true;
        }
    }
    
   
}
