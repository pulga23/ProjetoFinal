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
    private int weaponPart = 0; //variable to control the number of parts of the sling shot the player has 
    private bool playerHAsWeapon = false; //check if the player has all the parts and can use the weapom
    [SerializeField]
    GameObject playerAmmo; //what the player fires
    [SerializeField]
    public Transform cameraDirection;
    [SerializeField]
    GameObject aimPlayer;
    Vector3 auxAimPlayer;


    private void Start()
    {
        pickUpPrompt.gameObject.SetActive(false); //hide pick up prompt
        aimPlayer.gameObject.SetActive(false); //hide aim        
    }
    
    private void Update()
    {
        livesText.text = lives.ToString(); //print number of lives to screen
        Debug.Log(Input.mousePosition);
        
        if(playerHAsWeapon == true) //slingshot complete
        {
            if(Input.GetMouseButton(1)) //show aim
            {
                auxAimPlayer = Input.mousePosition;
                //auxAimPlayer = aimPlayer.gameObject.transform.position;
                auxAimPlayer.z = 0f;
                aimPlayer.gameObject.transform.position = auxAimPlayer;
                aimPlayer.gameObject.SetActive(true);
                if(Input.GetMouseButtonDown(0))
                {
                    //fires
                }
            }

        } 
    }
    
    //runs when the player touches something
    private void OnTriggerEnter(Collider other)
    {
        //palyer touches a poisonous plant
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
            if (Input.GetKeyDown(KeyCode.C))
            {
                Destroy(other.gameObject); //destroy weapon part game object
                weaponPart++;
                pickUpPrompt.gameObject.SetActive(false);
            }
        }
        if(weaponPart==3) //player has all the parts and can use the weapon
        {
            playerHAsWeapon = true;
        }
    }
    
    //player fires
    private void Fire()
    {

    }
}
