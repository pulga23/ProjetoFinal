using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    float force = 100f; //force to shoot the ammo
    Quaternion direction;
    Vector3 aux;

    // Start is called before the first frame update
    void Start()
    {
        direction = GameObject.FindWithTag("Player").GetComponent<Player>().cameraDirection.rotation; //quaternion with the current roation of the camera (where the player is looking)
        aux = direction * Vector3.right;
        aux.y = 0;
        aux.z = 0;
        GetComponent<Rigidbody>().AddForce( aux * force);
        Debug.Log("Fire!");
        Debug.Log(direction + " " + aux);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
