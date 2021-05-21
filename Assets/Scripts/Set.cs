using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    public bool setTurned = false; //public to use to control the player position

    Vector3 originalPostion;
    Quaternion originalRotation;
    Vector3 auxPosition;
    Quaternion auxRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if(Input.GetKeyDown(KeyCode.G))
        {
            if (setTurned == false)
            {
                originalPostion = transform.position;
                auxPosition = transform.position;
                transform.Rotate(new Vector3(90, 0, 0)); //rotates 90 degrees in the x axis
                auxPosition.x += -10f; //move the set -10units in the x axis
                transform.position = auxPosition;
                setTurned = true;
            }
            if(setTurned == true)
            {
                transform.Rotate(new Vector3(0, 0, 0)); //rotates set back to original position 
                transform.position = originalPostion; // moves the set back to the original position
                setTurned = false;
            }
        }*/

    }
    public void ActivatePortal()
    {
        
        auxPosition = player.gameObject.transform.position;
        //originalRotation = player.transform.rotation;
        //auxPosition = originalPostion;
        //auxRotation = originalRotation;
        auxPosition.y = -20;
        //auxRotation
        player.gameObject.transform.position = auxPosition;
       // Physics.gravity = new Vector3(0, 9.8f, 0);
    }
}
