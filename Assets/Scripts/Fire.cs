using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    float force = 100f; //force to shoot the ammo

    //[SerializeField]
    //GameObject aimGO; //
    
    //[SerializeField]
    //Transform playerTransform;

    [SerializeField]
    GameObject player;

    Transform aux;

    Vector3 playerTransform;
    Vector3 aimPosition;
    Vector3 playerPosition;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        //aux = player.GetComponentInChildren<Transform>();
        //playerPosition = playerGO.transform.position;
        //aimPosition = aimGO.transform.position;
        //direction = aimPosition - playerPosition;
        

        playerPosition = player.gameObject.transform.position;
        aimPosition.x = playerPosition.x;
        aimPosition.y = playerPosition.y + 0.8f;
        aimPosition.z = playerPosition.z + 0.65f;

        direction = aimPosition - playerPosition;

        GetComponent<Rigidbody>().AddForce( direction * force);
        Debug.Log("Fire!"+ direction);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
